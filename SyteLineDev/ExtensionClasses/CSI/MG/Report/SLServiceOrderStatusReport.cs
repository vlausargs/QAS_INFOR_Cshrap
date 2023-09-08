//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderStatusReport.cs

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
	[IDOExtensionClass("SLServiceOrderStatusReport")]
	public class SLServiceOrderStatusReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROStatusSp([Optional] string ExOptBegSRO_num,
		[Optional] string ExOptENDSRO_num,
		[Optional] int? ExOptBegSRO_Line,
		[Optional] int? ExOptENDSRO_Line,
		[Optional] int? ExOptBegSRO_Oper,
		[Optional] int? ExOptENDSRO_Oper,
		[Optional] string StartLeadPartner,
		[Optional] string EndLeadPartner,
		[Optional] string StartBillMgr,
		[Optional] string EndBillMgr,
		[Optional] string ExOptBegSRO_Type,
		[Optional] string ExOptENDSRO_Type,
		[Optional] string ExOptBegRegion,
		[Optional] string ExOptENDRegion,
		[Optional] string ExOptBegcust_num,
		[Optional] string ExOptENDcust_num,
		[Optional] string ExOptBegCust_Po,
		[Optional] string ExOptENDCust_Po,
		[Optional] string ExOptBegItem,
		[Optional] string ExOptENDItem,
		[Optional] string ExOptacSROStat,
		[Optional] string ExOptacSROBillStat,
		[Optional] string ExOptacLineStat,
		[Optional] string ExOptacLineBillStat,
		[Optional] string ExOptacOperStat,
		[Optional] string ExOptacOperBillStat,
		[Optional] DateTime? ExOptBegSROOpen_date,
		[Optional] DateTime? ExOptENDSROOpen_date,
		[Optional] DateTime? ExOptBegSROStart_date,
		[Optional] DateTime? ExOptENDSROStart_date,
		[Optional] int? StartSROOpen_dateOffSET,
		[Optional] int? ENDSROOpen_dateOffSET,
		[Optional] int? StartSROStart_dateOffSET,
		[Optional] int? ENDSROStart_dateOffSET,
		[Optional, DefaultParameterValue("O")] string SortBy,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROStatusExt = new SSSFSRpt_SROStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROStatusExt.SSSFSRpt_SROStatusSp(ExOptBegSRO_num,
				ExOptENDSRO_num,
				ExOptBegSRO_Line,
				ExOptENDSRO_Line,
				ExOptBegSRO_Oper,
				ExOptENDSRO_Oper,
				StartLeadPartner,
				EndLeadPartner,
				StartBillMgr,
				EndBillMgr,
				ExOptBegSRO_Type,
				ExOptENDSRO_Type,
				ExOptBegRegion,
				ExOptENDRegion,
				ExOptBegcust_num,
				ExOptENDcust_num,
				ExOptBegCust_Po,
				ExOptENDCust_Po,
				ExOptBegItem,
				ExOptENDItem,
				ExOptacSROStat,
				ExOptacSROBillStat,
				ExOptacLineStat,
				ExOptacLineBillStat,
				ExOptacOperStat,
				ExOptacOperBillStat,
				ExOptBegSROOpen_date,
				ExOptENDSROOpen_date,
				ExOptBegSROStart_date,
				ExOptENDSROStart_date,
				StartSROOpen_dateOffSET,
				ENDSROOpen_dateOffSET,
				StartSROStart_dateOffSET,
				ENDSROStart_dateOffSET,
				SortBy,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
