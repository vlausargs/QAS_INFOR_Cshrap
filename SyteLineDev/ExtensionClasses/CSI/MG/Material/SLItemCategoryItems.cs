//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemCategoryItems.cs

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
	[IDOExtensionClass("SLItemCategoryItems")]
	public class SLItemCategoryItems : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetCurrentSearchItemsSp(byte? MatchingItemsOnly,
		                                             Guid? RowPointer,
		                                             int? RecordCap,
		                                             string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetCurrentSearchItemsExt = new CLM_GetCurrentSearchItemsFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_GetCurrentSearchItemsExt.CLM_GetCurrentSearchItemsSp(MatchingItemsOnly,
				                                                                         RowPointer,
				                                                                         RecordCap,
				                                                                         FilterString);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetSearchItemsSp(string Criteria,
		                                      string CriterionTypes,
		                                      int? LocaleID,
		                                      string CustNum,
		                                      string ResellerCustNum,
		                                      string OrderBySel)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetSearchItemsExt = new CLM_GetSearchItemsFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCLM_GetSearchItemsExt.CLM_GetSearchItemsSp(Criteria,
				                                                           CriterionTypes,
				                                                           LocaleID,
				                                                           CustNum,
				                                                           ResellerCustNum,
				                                                           OrderBySel);
				
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateItemCategoryItemSp(int? Select,
		string Item,
		Guid? TreeRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateItemCategoryItemExt = new UpdateItemCategoryItemFactory().Create(appDb);
				
				var result = iUpdateItemCategoryItemExt.UpdateItemCategoryItemSp(Select,
				Item,
				TreeRowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
