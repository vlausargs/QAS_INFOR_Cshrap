//PROJECT NAME: FSPlusCallCenterExt
//CLASS NAME: FSKBases.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.CallCenter;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusCallCenter
{
    [IDOExtensionClass("FSKBases")]
    public class FSKBases : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSCreateKBaseRecordWrapperSp(string Keywords,
		string Desc,
		string Resolution,
		string Summary,
		Guid? RowPtr,
		ref int? NewKnowNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSCreateKBaseRecordWrapperExt = new SSSFSCreateKBaseRecordWrapperFactory().Create(appDb);
				
				var result = iSSSFSCreateKBaseRecordWrapperExt.SSSFSCreateKBaseRecordWrapperSp(Keywords,
				Desc,
				Resolution,
				Summary,
				RowPtr,
				NewKnowNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				NewKnowNum = result.NewKnowNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSKbaseSearchSp(string SearchType,
		string SearchText,
		int? SearchKeywords,
		int? SearchDescription,
		int? SearchSummary,
		int? SearchResolution,
		string CatGeneral,
		string CatSpecific,
		string CreatedBy,
		string UpdatedBy,
		string AvailableList)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSKbaseSearchExt = new SSSFSKbaseSearchFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSKbaseSearchExt.SSSFSKbaseSearchSp(SearchType,
				SearchText,
				SearchKeywords,
				SearchDescription,
				SearchSummary,
				SearchResolution,
				CatGeneral,
				CatSpecific,
				CreatedBy,
				UpdatedBy,
				AvailableList);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSPortalKbaseSearchSp(string SearchType,
		string SearchText,
		int? SearchKeywords,
		int? SearchDescription,
		int? SearchSummary,
		int? SearchResolution,
		string CatGeneral,
		string CatSpecific,
		string CreatedBy,
		string UpdatedBy,
		string AvailableList)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSPortalKbaseSearchExt = new SSSFSPortalKbaseSearchFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSPortalKbaseSearchExt.SSSFSPortalKbaseSearchSp(SearchType,
				SearchText,
				SearchKeywords,
				SearchDescription,
				SearchSummary,
				SearchResolution,
				CatGeneral,
				CatSpecific,
				CreatedBy,
				UpdatedBy,
				AvailableList);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
