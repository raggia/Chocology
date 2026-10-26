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
        private Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> m_PurchaserManagerCallback = delegate (string _iapID, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE _callBackState)
        {
        };
        private static Action s_InitializeSucceeded;
        public static global::System.Action InitializeSucceeded { get => s_InitializeSucceeded; set => s_InitializeSucceeded = value; }

        public static event Action RestoreCompleted;
        public static event Action RestoreFailed;
        private void Awake()
        {
            s_Instance = this;
            DontDestroyOnLoad(this);
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

        public void OnInitializeFailed(InitializationFailureReason error, string? message = null)
        {
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
            if (IsInitializedInternal())
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
                builder.AddProduct(iapID, ProductType.Consumable);
            }

            // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
            // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
            UnityPurchasing.Initialize(this, builder);
        }

        public bool IsInitialized() => IsInitializedInternal();
        private bool IsInitializedInternal()
        {
            //#if UNITY_EDITOR
            //        return true;
            //#endif
            // Only say we are initialized if both the Purchasing references are set.
            return s_StoreController != null && s_StoreExtensionProvider != null;
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
            m_PurchaserManagerCallback = _purchaserManager_Callback;
            // Buy the consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(iapID.ToString());
        }

        public void BuyNonConsumable(global::Rush.Chocology.Economy.Config.IAP_ID iapID, Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> _purchaserManager_Callback) => BuyNonConsumableInternal(iapID, _purchaserManager_Callback);
        private void BuyNonConsumableInternal(global::Rush.Chocology.Economy.Config.IAP_ID iapID, Action<string, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE> _purchaserManager_Callback)
        {
            m_PurchaserManagerCallback = _purchaserManager_Callback;
            // Buy the non-consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(iapID.ToString());
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

        void BuyProductID(string productId)
        {
            //
            // If Purchasing has been initialized ...
            if (IsInitializedInternal())
            {
                // ... look up the Product reference with the general product identifier and the Purchasing 
                // system's products collection.
                Product product = s_StoreController.products.WithID(productId);
                // If the look up found a product for this device's store and that product is ready to be sold ... 
                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                    // asynchronously.
                    s_StoreController.InitiatePurchase(product);
                }
                // Otherwise ...
                else
                {
                    // ... report the product look-up failure situation  
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            // Otherwise ...
            else
            {
                // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
                // retrying initiailization.
                Debug.Log("BuyProductID FAIL. Not initialized.");
                m_PurchaserManagerCallback.Invoke(productId, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.FAIL);
            }
        //#endif
        }

        // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
        // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
        public void RestorePurchases() => RestorePurchasesInternal();
        private void RestorePurchasesInternal()
        {
            // If Purchasing has not yet been set up ...
            if (!IsInitializedInternal())
            {
                // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            // If we are running on an Apple device ... 
            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
            {
                // ... begin restoring purchases
                Debug.Log("RestorePurchases started ...");
                // Fetch the Apple store-specific subsystem.
                var apple = s_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
                // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
                apple.RestoreTransactions((result, error) =>
                {
                    // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                    // no purchases are available to be restored.
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            // Otherwise ...
            else
            {
                // We are not running on an Apple device. No work is necessary to restore purchases.
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }

        //  
        // --- IStoreListener
        //
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");
            // Overall Purchasing system, configured with products for this application.
            s_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            s_StoreExtensionProvider = extensions;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            ////A consumable product has been purchased by this user.
            //if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
            //    //ScoreManager.score += 100;
            //    //PurchaserManager_Callback.Invoke(args.purchasedProduct.definition.id);
            //}
            //// Or ... a non-consumable product has been purchased by this user.
            //else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
            //}
            //// Or ... a subscription product has been purchased by this user.
            //else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
            //{
            //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //    // TODO: The subscription item has been successfully purchased, grant this to the player.
            //}
            //// Or ... an unknown product has been purchased by this user. Fill in additional products here....
            //else
            //{
            //    Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            //}
            //Return a flag indicating whether this product has completely been received, or if the application needs
            // to be reminded of this purchase at next app launch.Use PurchaseProcessingResult.Pending when still
            //saving purchased products to the cloud, and when that save is delayed.
            bool validPurchase = true; // Presume valid for platforms with no R.V.
            // Unity IAP's validation logic is only included on these platforms.
            //        #if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX || UNITY_EDITOR
            //        // Prepare the validator with the secrets we prepared in the Editor
            //        // obfuscation window.
            //        var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
            //                    AppleTangle.Data(), Application.identifier);
            //        try
            //        {
            //            // On Google Play, result has a single product ID.
            //            // On Apple stores, receipts contain multiple products.
            //            var result = validator.Validate(args.purchasedProduct.receipt);
            //            // For informational purposes, we list the receipt(s)
            //            Debug.Log("Receipt is valid. Contents:");
            //            foreach (IPurchaseReceipt productReceipt in result)
            //            {
            //                Debug.Log(productReceipt.productID);
            //                Debug.Log(productReceipt.purchaseDate);
            //                Debug.Log(productReceipt.transactionID);
            //            }
            //        }
            //        catch (IAPSecurityException)
            //        {
            //            Debug.Log("Invalid receipt, not unlocking content");
            //            validPurchase = false;
            //        }
            //#endif
            if (validPurchase)
            {
                // Unlock the appropriate content here.
                m_PurchaserManagerCallback.Invoke(args.purchasedProduct.definition.id, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.SUCCESS);
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.IAPPurchasedSuccess();
            }
            else
            {
                m_PurchaserManagerCallback.Invoke(args.purchasedProduct.definition.id, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.FAIL);
                global::Rush.Chocology.Integrations.Analytics.AdjustManager.instance.IAPPurchasedFailed();
            }

            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
            // this reason with the user to guide their troubleshooting actions.
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
            m_PurchaserManagerCallback.Invoke(product.definition.id, global::Rush.Chocology.Integrations.Purchasing.PurchaserManager.IAP_CALLBACK_STATE.FAIL);
        }

        public string ReadLocalizedPriceString(string iapID) => ReadLocalizedPriceStringInternal(iapID);
        private string ReadLocalizedPriceStringInternal(string iapID)
        {
#if UNITY_EDITOR
            return "0.01$";
#endif
            //Debug.Log("GetLocalizedPriceString:"+ iapID);
            var product = s_StoreController.products.WithID(iapID);
            //Debug.Log("GetLocalizedPriceString:" + product);
            //Debug.Log("GetLocalizedPriceString:" + product.metadata.localizedPriceString);
            if (product != null)
            {
                return product.metadata.localizedPriceString;
            }
            else
            {
                return "0.01$";
            }
        }

        public enum IAP_CALLBACK_STATE
        {
            SUCCESS,
            FAIL
        }
    }
}
