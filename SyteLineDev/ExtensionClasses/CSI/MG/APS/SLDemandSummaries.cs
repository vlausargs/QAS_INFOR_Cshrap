//PROJECT NAME: APSExt
//CLASS NAME: SLDemandSummaries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
	[IDOExtensionClass("SLDemandSummaries")]
	public class SLDemandSummaries : ExtensionClassBase
	{






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetDemandIdSp(string PDemandType,
		int? AltNo,
		[Optional] string DemandIdFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetDemandIdExt = new CLM_ApsGetDemandIdFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetDemandIdExt.CLM_ApsGetDemandIdSp(PDemandType,
				AltNo,
				DemandIdFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetDemandSummarySp(DateTime? PStartDate,
		DateTime? PEndDate,
		string PDemandType,
		string PDemandID,
		string PItem,
		string PCustomer,
		string PLateness,
		string PCriticalItem,
		int? PShowPLN,
		string PPlanCode,
		string PWildCardChar,
		int? AltNo,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetDemandSummaryExt = new CLM_ApsGetDemandSummaryFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetDemandSummaryExt.CLM_ApsGetDemandSummarySp(PStartDate,
				PEndDate,
				PDemandType,
				PDemandID,
				PItem,
				PCustomer,
				PLateness,
				PCriticalItem,
				PShowPLN,
				PPlanCode,
				PWildCardChar,
				AltNo,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_ApsGetDemandSummarySp(DateTime? PStartDate,
		DateTime? PEndDate,
		string PDemandType,
		string PDemandID,
		string PItem,
		string PCustomer,
		string PLateness,
		string PCriticalItem,
		int? PShowPLN,
		string PPlanCode,
		string PWildCardChar,
		int? AltNo,
		string SiteGroup,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iHome_ApsGetDemandSummaryExt = new Home_ApsGetDemandSummaryFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iHome_ApsGetDemandSummaryExt.Home_ApsGetDemandSummarySp(PStartDate,
				PEndDate,
				PDemandType,
				PDemandID,
				PItem,
				PCustomer,
				PLateness,
				PCriticalItem,
				PShowPLN,
				PPlanCode,
				PWildCardChar,
				AltNo,
				SiteGroup,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
