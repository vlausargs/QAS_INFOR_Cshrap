//PROJECT NAME: ReportExt
//CLASS NAME: SLIncidentReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLIncidentReport")]
	public class SLIncidentReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_IncidentSp([Optional] string ExOptBegInc_num,
		[Optional] string ExOptEndInc_num,
		[Optional] string ExOptBegcust_num,
		[Optional] string ExOptENDcust_num,
		[Optional] string ExOptBegItem,
		[Optional] string ExOptENDItem,
		[Optional] string ExOptBegOwner,
		[Optional] string ExOptENDOwner,
		[Optional] string ExOptBegUnit,
		[Optional] string ExOptENDUnit,
		[Optional] string ExOptBegPriorCode,
		[Optional] string ExOptENDPriorCode,
		[Optional] string ExOptBegStatCode,
		[Optional] string ExOptENDStatCode,
		[Optional] DateTime? ExOptBegInc_date,
		[Optional] DateTime? ExOptENDInc_date,
		[Optional] int? StartInc_dateOffSET,
		[Optional] int? ENDInc_dateOffSET,
		[Optional] string ExOptBegReasonGen,
		[Optional] string ExOptENDReasonGen,
		[Optional] string ExOptBegReasonSpec,
		[Optional] string ExOptENDReasonSpec,
		[Optional] string ExOptBegSSR,
		[Optional] string ExOptENDSSR,
		[Optional, DefaultParameterValue(1)] int? ExOptIncIntNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptIncExtNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptCustIntNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptCustExtNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptEvents,
		[Optional, DefaultParameterValue(1)] int? ExOptEventIntNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptEventExtNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptReasons,
		[Optional, DefaultParameterValue(1)] int? ExOptReasonNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptResNotes,
		[Optional, DefaultParameterValue("I")] string SortBy,
		[Optional, DefaultParameterValue("B")] string IncStat,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_IncidentExt = new SSSFSRpt_IncidentFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_IncidentExt.SSSFSRpt_IncidentSp(ExOptBegInc_num,
				ExOptEndInc_num,
				ExOptBegcust_num,
				ExOptENDcust_num,
				ExOptBegItem,
				ExOptENDItem,
				ExOptBegOwner,
				ExOptENDOwner,
				ExOptBegUnit,
				ExOptENDUnit,
				ExOptBegPriorCode,
				ExOptENDPriorCode,
				ExOptBegStatCode,
				ExOptENDStatCode,
				ExOptBegInc_date,
				ExOptENDInc_date,
				StartInc_dateOffSET,
				ENDInc_dateOffSET,
				ExOptBegReasonGen,
				ExOptENDReasonGen,
				ExOptBegReasonSpec,
				ExOptENDReasonSpec,
				ExOptBegSSR,
				ExOptENDSSR,
				ExOptIncIntNotes,
				ExOptIncExtNotes,
				ExOptCustIntNotes,
				ExOptCustExtNotes,
				ExOptEvents,
				ExOptEventIntNotes,
				ExOptEventExtNotes,
				ExOptReasons,
				ExOptReasonNotes,
				ExOptResNotes,
				SortBy,
				IncStat,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
