//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemCategories.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemCategories")]
	public class SLItemCategories : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CategoryActiveSp(string ItemCategory,
		                            byte? Active,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCategoryActiveExt = new CategoryActiveFactory().Create(appDb);
				
				int Severity = iCategoryActiveExt.CategoryActiveSp(ItemCategory,
				                                                   Active,
				                                                   ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int DeleteItemsOfSpecifiedCategoriesSp(string ItemCategory)
        {
            var iDeleteItemsOfSpecifiedCategoriesExt = new DeleteItemsOfSpecifiedCategoriesFactory().Create(this, true);

            var result = iDeleteItemsOfSpecifiedCategoriesExt.DeleteItemsOfSpecifiedCategoriesSp(ItemCategory);


            return result ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int IsCategoryHeadingInUseSp(string ItemCategory,
		                                    ref byte? IsCategoryHeadingInUse,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsCategoryHeadingInUseExt = new IsCategoryHeadingInUseFactory().Create(appDb);
				
				int Severity = iIsCategoryHeadingInUseExt.IsCategoryHeadingInUseSp(ItemCategory,
				                                                                   ref IsCategoryHeadingInUse,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateItemCategoryHierarchySp(int? Select,
		string ItemCategory,
		int? Rank,
		Guid? ParentRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateItemCategoryHierarchyExt = new UpdateItemCategoryHierarchyFactory().Create(appDb);
				
				var result = iUpdateItemCategoryHierarchyExt.UpdateItemCategoryHierarchySp(Select,
				ItemCategory,
				Rank,
				ParentRowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetCurrentSearchItemCategoriesSp(int? ChildCategoriesOnly,
		Guid? RowPointer,
		int? RecordCap,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetCurrentSearchItemCategoriesExt = new CLM_GetCurrentSearchItemCategoriesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetCurrentSearchItemCategoriesExt.CLM_GetCurrentSearchItemCategoriesSp(ChildCategoriesOnly,
				RowPointer,
				RecordCap,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
