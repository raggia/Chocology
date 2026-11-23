using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

namespace Rush.Chocology.Integrations.Purchasing
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "", "Assembly-CSharp", "PurchaserManager")]
    public class PurchaserManager : MonoBehaviour, IStoreListener
    {
        private static global::Rush.Chocology.Integrations.Purchasing.PurchaserManager s_Instance;
        public static global::Rush.Chocology.Integrations.Purchasing.PurchaserManager Instance { get => s_Instance; set => s_Instance = value; }

        private static IStoreController s_StoreController;
        private static IExtensionProvider s_StoreExtensionProvider;
        private static string s_KProductIDConsumable = "consumable";
        public static string KProductIDConsumable { get => s_KProductIDConsumable; set => s_KProductIDConsumable = value; }

        private static string s_KProductIDNonConsumable = "nonconsumable";
        public static string KProductIDNonConsumable { get => s_KProductIDNonConsumable; set => s_KProductIDNonConsumable = value; }

        private static string s_KProductIDSubscription = "subscription";
        public static string KProductIDSubscription { get => s_KProductIDSubscription; set => s_KProductIDSubscription = value; }

        private static string s_KProductNameAppleSubscription = "com.unity3d.subscription.new";
        private static string s_KProductNameGooglePlaySubscription = "com.unity3d.subscription.original";
        private Action<string, IAP_CALLBACK_STATE> m_PurchaserManagerCallback;
        private string m_ActiveProductId;
        private bool m_Initializing;
        private StoreController m_StoreEvents;
        private bool m_StoreConnected;
        private readonly Dictionary<string, Product> m_PendingPurchases = new Dictionary<string, Product>();
        private const string c_TransactionPrefix = "iap_fulfilled_";
        private static Action s_InitializeSucceeded;
        public static global::System.Action InitializeSucceeded { get => s_InitializeSucceeded; set => s_InitializeSucceeded = value; }

        public static event Action RestoreCompleted;
        public static event Action RestoreFailed;
        private void Awake()
        {
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (s_StoreController == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasingInternal();
            }
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message = null)
        {
            m_Initializing = false;
            var errorMessage = $"Purchasing failed to initialize. Reason: {(error)}.";
            if (message != null)
            {
                errorMessage += $" More details: {(message)}";
            }

            Debug.Log(errorMessage);
        }

        public void InitializePurchasing() => InitializePurchasingInternal();
        private void InitializePurchasingInternal()
        {
            // If we have already connected to Purchasing ...
            if (m_Initializing || IsInitializedInternal())
            {
                // ... we are done here.
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            // Add a product to sell / restore by way of its identifier, associating the general identifier
            // with its store-specific identifiers.
            //builder.AddProduct(kProductIDConsumable, ProductType.Consumable);
            //// Continue adding the non-consumable product.
            //builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);
            //// And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
            //// if the Product ID was configured differently between Apple and Google stores. Also note that
            //// one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
            //// must only be referenced here. 
            //builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
            //        { kProductNameAppleSubscription, AppleAppStore.Name },
            //        { kProductNameGooglePlaySubscription, GooglePlay.Name },
            //    });
            //builder.AddProduct(Config.IAP_ID.removeAd.ToString(), ProductType.NonConsumable);
            foreach (string iapID in Enum.GetNames(typeof(global::Rush.Chocology.Economy.Config.IAP_ID)))
            {
                //if (!iapID.Equals(Config.IAP_ID.removeAd))
                //{
                //    builder.AddProduct(iapID, ProductType.Consumable);
                //}
                builder.AddProduct(iapID, iapID == global::Rush.Chocology.Economy.Config.IAP_ID.removead.ToString() ? ProductType.NonConsumable : ProductType.Consumable);
            }

            // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
            // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
            if (m_StoreEvents == null)
            {
                m_StoreEvents = new StoreController();
                m_StoreEvents.OnStoreConnected += OnStoreConnected;
                m_StoreEvents.OnStoreDisconnected += OnStoreDisconnected;
                m_StoreEvents.OnPurchasesFetchFailed += OnPurchasesFetchFailed;
                m_StoreEvents.ProcessPendingOrdersOnPurchasesFetched(true);
            }
            m_Initializing = true;
            UnityPurchasing.Initialize(this, builder);
        }

        public bool IsInitialized() => IsInitializedInternal();
        private bool IsInitializedInternal()
        {
            //#if UNITY_EDITOR
            //        return true;
            //#endif
            // Only say we are initialized if both the Purchasing references are set.
            return m_StoreConnected && s_StoreController != null && s_StoreExtensionProvider != null;
        }

        public void BuyConsumable() => BuyConsumableInternal();
        private void BuyConsumableInternal()
        {
            // Buy the consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(s_KProductIDConsumable);
        }

        public void BuyConsumable(global::Rush.Chocology.Economy.Config.IAP_ID iapID, Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> _purchaserManager_Callback) => BuyConsumableInternal(iapID, _purchaserManager_Callback);
        private void BuyConsumableInternal(global::Rush.Chocology.Economy.Config.IAP_ID iapID, Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> _purchaserManager_Callback)
        {
            BeginPurchaseInternal(iapID.ToString(), _purchaserManager_Callback);
        }

        public void BuyNonConsumable(global::Rush.Chocology.Economy.Config.IAP_ID iapID, Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> _purchaserManager_Callback) => BuyNonConsumableInternal(iapID, _purchaserManager_Callback);
        private void BuyNonConsumableInternal(global::Rush.Chocology.Economy.Config.IAP_ID iapID, Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> _purchaserManager_Callback)
        {
            BeginPurchaseInternal(iapID.ToString(), _purchaserManager_Callback);
        }

        public void BuyNonConsumable() => BuyNonConsumableInternal();
        private void BuyNonConsumableInternal()
        {
            // Buy the non-consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(s_KProductIDNonConsumable);
        }

        public void BuySubscription() => BuySubscriptionInternal();
        private void BuySubscriptionInternal()
        {
            // Buy the subscription product using its the general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            // Notice how we use the general product identifier in spite of this ID being mapped to
            // custom store-specific identifiers above.
            BuyProductID(s_KProductIDSubscription);
        }

        private void BeginPurchaseInternal(string productId, Action<string, IAP_CALLBACK_STATE> callback)
        {
            if (m_ActiveProductId != null)
            {
                callback?.Invoke(productId, IAP_CALLBACK_STATE.FAIL);
                return;
            }
            m_PurchaserManagerCallback = callback;
            m_ActiveProductId = productId;
            if (m_PendingPurchases.TryGetValue(productId, out var pending))
            {
                if (ProcessPurchaseInternal(pending) == PurchaseProcessingResult.Complete)
                {
                    m_PendingPurchases.Remove(productId);
                    s_StoreController.ConfirmPendingPurchase(pending);
                }
                return;
            }
            BuyProductID(productId);
        }

        private void CompletePurchaseInternal(string productId, IAP_CALLBACK_STATE state)
        {
            if (m_ActiveProductId != productId)
                return;
            var callback = m_PurchaserManagerCallback;
            m_PurchaserManagerCallback = null;
            m_ActiveProductId = null;
            callback?.Invoke(productId, state);
        }

        private void BuyProductID(string productId)
        {
            if (!IsInitializedInternal())
            {
                CompletePurchaseInternal(productId, IAP_CALLBACK_STATE.FAIL);
                return;
            }
            Product product = s_StoreController.products.WithID(productId);
            if (product == null || !product.availableToPurchase)
            {
                CompletePurchaseInternal(productId, IAP_CALLBACK_STATE.FAIL);
                return;
            }
            try
            {
                s_StoreController.InitiatePurchase(product);
            }
            catch (Exception exception)
            {
                Debug.LogWarning("The store could not start this purchase: " + exception.GetType().Name, this);
                CompletePurchaseInternal(productId, IAP_CALLBACK_STATE.FAIL);
            }
        }

        // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
        // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
        public void RestorePurchases() => RestorePurchasesInternal();
        private void RestorePurchasesInternal()
        {
            if (!IsInitializedInternal())
            {
                RestoreFailed?.Invoke();
                return;
            }
            if (Application.platform == RuntimePlatform.Android)
                s_StoreExtensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions(OnRestoreFinished);
            else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
                s_StoreExtensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions(OnRestoreFinished);
            else
                RestoreFailed?.Invoke();
        }

        private void OnRestoreFinished(bool success, string error)
        {
            if (success)
                RestoreCompleted?.Invoke();
            else
                RestoreFailed?.Invoke();
        }

        //  
        // --- IStoreListener
        //
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");
            // Overall Purchasing system, configured with products for this application.
            m_Initializing = false;
            s_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            s_StoreExtensionProvider = extensions;
            s_InitializeSucceeded?.Invoke();
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            m_Initializing = false;
            Debug.LogWarning("Purchasing is unavailable: " + error);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) => ProcessPurchaseInternal(args.purchasedProduct);

        private PurchaseProcessingResult ProcessPurchaseInternal(Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.transactionID) || string.IsNullOrEmpty(product.receipt))
                return PurchaseProcessingResult.Pending;
            string id = product.definition.id;
#if UNITY_ANDROID && !UNITY_EDITOR
            if (!HasValidGoogleReceipt(product.receipt, id, GooglePlayTangle.Data(), Application.identifier))
            {
                Debug.LogWarning("Purchase receipt could not be verified. No content was granted.", this);
                CompletePurchaseInternal(id, IAP_CALLBACK_STATE.FAIL);
                return PurchaseProcessingResult.Pending;
            }
#endif
            string transactionKey = c_TransactionPrefix + product.transactionID;
            bool removeAds = id == global::Rush.Chocology.Economy.Config.IAP_ID.removead.ToString();
            if (removeAds && global::Rush.Chocology.Economy.Config.Runtime != null)
            {
                global::Rush.Chocology.Economy.Config.Runtime.SetRemoveAd();
                global::Rush.Chocology.Economy.Config.Runtime.SetBuyIAP(global::Rush.Chocology.Economy.Config.IAP_ID.removead);
            }
            if (PlayerPrefs.HasKey(transactionKey))
            {
                CompletePurchaseInternal(id, IAP_CALLBACK_STATE.FAIL);
                return PurchaseProcessingResult.Complete;
            }
            if (!removeAds && (m_ActiveProductId != id || m_PurchaserManagerCallback == null))
            {
                // Preserve interrupted purchases until the matching shop action can fulfill them.
                m_PendingPurchases[id] = product;
                return PurchaseProcessingResult.Pending;
            }
            if (removeAds && global::Rush.Chocology.Economy.Config.Runtime == null)
                return PurchaseProcessingResult.Pending;
            try
            {
                CompletePurchaseInternal(id, IAP_CALLBACK_STATE.SUCCESS);
            }
            catch (Exception exception)
            {
                Debug.LogWarning("Purchase fulfillment will be retried: " + exception.GetType().Name, this);
                m_PendingPurchases[id] = product;
                return PurchaseProcessingResult.Pending;
            }
            PlayerPrefs.SetInt(transactionKey, 1);
            PlayerPrefs.Save();
            m_PendingPurchases.Remove(id);
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            if (product != null)
                CompletePurchaseInternal(product.definition.id, IAP_CALLBACK_STATE.FAIL);
        }

        public string ReadLocalizedPriceString(string iapID) => ReadLocalizedPriceStringInternal(iapID);
        private string ReadLocalizedPriceStringInternal(string iapID)
        {
            var product = s_StoreController?.products.WithID(iapID);
            return product != null && product.availableToPurchase ? product.metadata.localizedPriceString : "Unavailable";
        }

        internal static bool HasValidGoogleReceipt(string receipt, string productId, byte[] publicKey, string bundleId)
        {
            try
            {
                var validator = new CrossPlatformValidator(publicKey, bundleId);
                var receipts = validator.Validate(receipt);
                return Array.Exists(receipts, item => item.productID == productId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void OnStoreConnected() => m_StoreConnected = true;

        private void OnStoreDisconnected(StoreConnectionFailureDescription failure)
        {
            m_StoreConnected = false;
            m_Initializing = false;
            if (m_ActiveProductId != null)
                CompletePurchaseInternal(m_ActiveProductId, IAP_CALLBACK_STATE.FAIL);
        }

        private void OnPurchasesFetchFailed(PurchasesFetchFailureDescription failure)
        {
            Debug.LogWarning("The store could not restore purchases. Retry when connected.", this);
            RestoreFailed?.Invoke();
        }

        private void OnDestroy()
        {
            if (m_StoreEvents != null)
            {
                m_StoreEvents.OnStoreConnected -= OnStoreConnected;
                m_StoreEvents.OnStoreDisconnected -= OnStoreDisconnected;
                m_StoreEvents.OnPurchasesFetchFailed -= OnPurchasesFetchFailed;
            }
            if (s_Instance == this)
                s_Instance = null;
        }

        public enum IAP_CALLBACK_STATE
        {
            SUCCESS,
            FAIL
        }
    }
}
