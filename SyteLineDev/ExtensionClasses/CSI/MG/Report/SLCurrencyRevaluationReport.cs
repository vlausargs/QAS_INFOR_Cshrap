//PROJECT NAME: ReportExt
//CLASS NAME: SLCurrencyRevaluationReport.cs

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
    [IDOExtensionClass("SLCurrencyRevaluationReport")]
    public class SLCurrencyRevaluationReport : ExtensionClassBase
    {
       
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CurrencyRevaluationSp([Optional] byte? pRelGl,
		                                           [Optional] byte? pPostTrx,
		                                           [Optional] string pSCurrCode,
		                                           [Optional] string pECurrCode,
		                                           [Optional] byte? pRcvAcctType,
		                                           [Optional] byte? pPayAcctType,
		                                           [Optional] byte? pVouchPayAcctType,
		                                           [Optional] DateTime? pTTransDate,
		                                           [Optional] string pInvAdjAcct,
		                                           [Optional] string pInvAdjAcctUnit1,
		                                           [Optional] string pInvAdjAcctUnit2,
		                                           [Optional] string pInvAdjAcctUnit3,
		                                           [Optional] string pInvAdjAcctUnit4,
		                                           [Optional] short? DateOffset,
		                                           [Optional] byte? DisplayHeader,
		                                           [Optional] int? TaskId,
		                                           [Optional] string pSite,
		                                           [Optional, DefaultParameterValue(0)] int? ReportType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CurrencyRevaluationExt = new Rpt_CurrencyRevaluationFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CurrencyRevaluationExt.Rpt_CurrencyRevaluationSp(pRelGl,
				                                                                   pPostTrx,
				                                                                   pSCurrCode,
				                                                                   pECurrCode,
				                                                                   pRcvAcctType,
				                                                                   pPayAcctType,
				                                                                   pVouchPayAcctType,
				                                                                   pTTransDate,
				                                                                   pInvAdjAcct,
				                                                                   pInvAdjAcctUnit1,
				                                                                   pInvAdjAcctUnit2,
				                                                                   pInvAdjAcctUnit3,
				                                                                   pInvAdjAcctUnit4,
				                                                                   DateOffset,
				                                                                   DisplayHeader,
				                                                                   TaskId,
				                                                                   pSite,
				                                                                   ReportType);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
