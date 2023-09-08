//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemCategoryHierarchies.cs

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
	[IDOExtensionClass("SLItemCategoryHierarchies")]
	public class SLItemCategoryHierarchies : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemCategoryHierarchyCurrentSearchSp(Guid? RowPointer,
		                                                   ref string CurrentSearch)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetItemCategoryHierarchyCurrentSearchExt = new GetItemCategoryHierarchyCurrentSearchFactory().Create(appDb);
				
				int Severity = iGetItemCategoryHierarchyCurrentSearchExt.GetItemCategoryHierarchyCurrentSearchSp(RowPointer,
				                                                                                                 ref CurrentSearch);
				
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
		public DataTable CLM_GetCurrentSearchItemCategoryHierarchiesSp(string Criteria,
		string CriterionTypes,
		int? LocaleID,
		Guid? SessionId,
		Guid? CatalogRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetCurrentSearchItemCategoryHierarchiesExt = new CLM_GetCurrentSearchItemCategoryHierarchiesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetCurrentSearchItemCategoryHierarchiesExt.CLM_GetCurrentSearchItemCategoryHierarchiesSp(Criteria,
				CriterionTypes,
				LocaleID,
				SessionId,
				CatalogRowPointer);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
