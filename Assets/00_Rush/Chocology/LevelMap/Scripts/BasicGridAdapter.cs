/*
 * * * * This bare-bones script was auto-generated * * * *
 * The code commented with "/ * * /" demonstrates how data is retrieved and passed to the adapter, plus other common commands. You can remove/replace it once you've got the idea
 * Complete it according to your specific use-case
 * Consult the Example scripts if you get stuck, as they provide solutions to most common scenarios
 * 
 * Main terms to understand:
 *		Model = class that contains the data associated with an item (title, content, icon etc.)
 *		Views Holder = class that contains references to your views (Text, Image, MonoBehavior, etc.)
 * 
 * Default expected UI hiererchy:
 *	  ...
 *		-Canvas
 *		  ...
 *			-MyScrollViewAdapter
 *				-Viewport
 *					-Content
 *				-Scrollbar (Optional)
 *				-ItemPrefab (Optional)
 * 
 * Note: If using Visual Studio and opening generated scripts for the first time, sometimes Intellisense (autocompletion)
 * won't work. This is a well-known bug and the solution is here: https://developercommunity.visualstudio.com/content/problem/130597/unity-intellisense-not-working-after-creating-new-1.html (or google "unity intellisense not working new script")
 * 
 * 
 * Please read the manual under "Assets/OSA/Docs", as it contains everything you need to know in order to get started, including FAQ
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Other.Extensions;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;

namespace Rush.Chocology.LevelMap
{
    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Grids", "Assembly-CSharp", "BasicGridAdapter")]
    // There is 1 important callback you need to implement, apart from Start(): UpdateCellViewsHolder()
    // See explanations below
    public class BasicGridAdapter : GridAdapter<GridParams, MyGridItemViewsHolder>
    {
        // Helper that stores data and notifies the adapter when items count changes
        // Can be iterated and can also have its elements accessed by the [] operator
        public SimpleDataHelper<global::Rush.Chocology.LevelMap.MyGridItemModel> Data { get; private set; }

        protected override void Start()
        {
            Data = new SimpleDataHelper<global::Rush.Chocology.LevelMap.MyGridItemModel>(this);
            // Calling this initializes internal data and prepares the adapter to handle item count changes
            base.Start();
            // Retrieve the models from your data source and set the items count
            RetrieveDataAndUpdate(global::Rush.Chocology.Economy.Config.MAX_LEVEL);
        }

        // This is called anytime a previously invisible item become visible, or after it's created, 
        // or when anything that requires a refresh happens
        // Here you bind the data from the model to the item's views
        // *For the method's full description check the base implementation
        protected override void UpdateCellViewsHolder(global::Rush.Chocology.LevelMap.MyGridItemViewsHolder newOrRecycled)
        {
            // In this callback, "newOrRecycled.ItemIndex" is guaranteed to always reflect the
            // index of item that should be represented by this views holder. You'll use this index
            // to retrieve the model from your data set
            global::Rush.Chocology.LevelMap.MyGridItemModel model = Data[newOrRecycled.ItemIndex];
            //newOrRecycled.backgroundImage.color = model.color;
            //newOrRecycled.titleText.text = model.title + " #" + newOrRecycled.ItemIndex;
            global::Rush.Chocology.Core.RushComponentAccess.Resolve<global::Rush.Chocology.LevelMap.ItemLevel>(//newOrRecycled.backgroundImage.color = model.color;
            //newOrRecycled.titleText.text = model.title + " #" + newOrRecycled.ItemIndex;
            newOrRecycled.ItemLevel).SetInitItemLevel(model.InfoLevel);
        }

        // This is the best place to clear an item's views in order to prepare it from being recycled, but this is not always needed, 
        // especially if the views' values are being overwritten anyway. Instead, this can be used to, for example, cancel an image 
        // download request, if it's still in progress when the item goes out of the viewport.
        // <newItemIndex> will be non-negative if this item will be recycled as opposed to just being disabled
        // *For the method's full description check the base implementation
        /*
		protected override void OnBeforeRecycleOrDisableCellViewsHolder(MyGridItemViewsHolder inRecycleBinOrVisible, int newItemIndex)
		{
			base.OnBeforeRecycleOrDisableCellViewsHolder(inRecycleBinOrVisible, newItemIndex);
		}
		*/

        // These are common data manipulation methods
        // The list containing the models is managed by you. The adapter only manages the items' sizes and the count
        // The adapter needs to be notified of any change that occurs in the data list. 
        // For GridAdapters, only Refresh and ResetItems work for now

        public void AddItemsAt(int index, IList<global::Rush.Chocology.LevelMap.MyGridItemModel> items) => AddItemsAtInternal(index, items);
        private void AddItemsAtInternal(int index, IList<global::Rush.Chocology.LevelMap.MyGridItemModel> items)
        {
            //Commented: this only works with Lists. ATM, Insert for Grids only works by manually changing the list and calling NotifyListChangedExternally() after
            //Data.InsertItems(index, items);
            Data.List.InsertRange(index, items);
            Data.NotifyListChangedExternally();
        }

        public void RemoveItemsFrom(int index, int count) => RemoveItemsFromInternal(index, count);
        private void RemoveItemsFromInternal(int index, int count)
        {
            //Commented: this only works with Lists. ATM, Remove for Grids only works by manually changing the list and calling NotifyListChangedExternally() after
            //Data.RemoveRange(index, count);
            Data.List.RemoveRange(index, count);
            Data.NotifyListChangedExternally();
        }

        public void SetItems(IList<global::Rush.Chocology.LevelMap.MyGridItemModel> items) => SetItemsInternal(items);
        private void SetItemsInternal(IList<global::Rush.Chocology.LevelMap.MyGridItemModel> items)
        {
            Data.ResetItems(items);
        }

        // Here, we're requesting <count> items from the data source
        void RetrieveDataAndUpdate(int count)
        {
            StartCoroutine(FetchMoreItemsFromDataSourceAndUpdate(count));
        }

        // Retrieving <count> models from the data source and calling OnDataRetrieved after.
        // In a real case scenario, you'd query your server, your database or whatever is your data source and call OnDataRetrieved after
        IEnumerator FetchMoreItemsFromDataSourceAndUpdate(int count)
        {
            // Simulating data retrieving delay
            yield return new WaitForSeconds(.5f);
            var newItems = new global::Rush.Chocology.LevelMap.MyGridItemModel[count];
            // Retrieve your data here
            /*
			for (int i = 0; i < count; ++i)
			{
				var model = new MyGridItemModel()
				{
					title = "Random item ",
					color = new Color(
								UnityEngine.Random.Range(0f, 1f),
								UnityEngine.Random.Range(0f, 1f),
								UnityEngine.Random.Range(0f, 1f),
								UnityEngine.Random.Range(0f, 1f)
							)
				};
				newItems[i] = model;
			}
			*/
            for (int i = 0; i < count; ++i)
            {
                global::Rush.Chocology.LevelMap.MyGridItemModel model = new global::Rush.Chocology.LevelMap.MyGridItemModel();
                global::Rush.Chocology.Gameplay.InfoLevel infoLevel = new global::Rush.Chocology.Gameplay.InfoLevel(i + 1, 0);
                if (global::Rush.Chocology.Economy.Config.Runtime.CurrDicLevelStars.ContainsKey(infoLevel.Level))
                {
                    infoLevel.Star = global::Rush.Chocology.Economy.Config.Runtime.CurrDicLevelStars[infoLevel.Level];
                }

                model.InfoLevel = infoLevel;
                newItems[i] = model;
            }

            OnDataRetrieved(newItems);
        }

        void OnDataRetrieved(global::Rush.Chocology.LevelMap.MyGridItemModel[] newItems)
        {
            //Commented: this only works with Lists. ATM, Insert for Grids only works by manually changing the list and calling NotifyListChangedExternally() after
            // Data.InsertItemsAtEnd(newItems);
            Data.List.AddRange(newItems);
            Data.NotifyListChangedExternally();
        }
    }

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Grids", "Assembly-CSharp", "MyGridItemModel")]
    // Class containing the data associated with an item
    public class MyGridItemModel
    {
        [UnityEngine.Serialization.FormerlySerializedAs("infoLevel")]
        [UnityEngine.SerializeField]
        private global::Rush.Chocology.Gameplay.InfoLevel m_InfoLevel;
        public global::Rush.Chocology.Gameplay.InfoLevel InfoLevel { get => m_InfoLevel; set => m_InfoLevel = value; }
    }

    [UnityEngine.Scripting.APIUpdating.MovedFrom(true, "Your.Namespace.Here.UniqueStringHereToAvoidNamespaceConflicts.Grids", "Assembly-CSharp", "MyGridItemViewsHolder")]
    // This class keeps references to an item's views.
    // Your views holder should extend BaseItemViewsHolder for ListViews and CellViewsHolder for GridViews
    // The cell views holder should have a single child (usually named "Views"), which contains the actual 
    // UI elements. A cell's root is never disabled - when a cell is removed, only its "views" GameObject will be disabled
    public class MyGridItemViewsHolder : CellViewsHolder
    {
        [UnityEngine.Serialization.FormerlySerializedAs("itemLevel")]
        [UnityEngine.SerializeField]
        private Component m_ItemLevel;
        public global::UnityEngine.Component ItemLevel { get => m_ItemLevel; set => m_ItemLevel = value; }

        // Retrieving the views from the item's root GameObject
        public override void CollectViews()
        {
            base.CollectViews();
            // GetComponentAtPath is a handy extension method from frame8.Logic.Misc.Other.Extensions
            // which infers the variable's component from its type, so you won't need to specify it yourself
            /*
			views.GetComponentAtPath("TitleText", out titleText);
			views.GetComponentAtPath("BackgroundImage", out backgroundImage);
			*/
            views.GetComponentAtPath("itemLevelView", out m_ItemLevel);
        }
    // This is usually the only child of the item's root and it's called "Views". 
    // That's what the default implementation will look for, but just for flexibility, 
    // this callback is provided, in case it's named differently or there's more than 1 child 
    // *See GridExample.cs for more info
    /*
		protected override RectTransform GetViews()
		{ return root.Find("Views").transform as RectTransform; }
		*/
    // Override this if you have children layout groups. They need to be marked for rebuild when this callback is fired
    /*
		public override void MarkForRebuild()
		{
			base.MarkForRebuild();

			LayoutRebuilder.MarkLayoutForRebuild(yourChildLayout1);
			LayoutRebuilder.MarkLayoutForRebuild(yourChildLayout2);
			AChildSizeFitter.enabled = true;
		}
		*/
    // Override this if you've also overridden MarkForRebuild()
    /*
		public override void UnmarkForRebuild()
		{
			AChildSizeFitter.enabled = false;

			base.UnmarkForRebuild();
		}
		*/
    }
}
