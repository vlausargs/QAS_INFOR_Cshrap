//PROJECT NAME: ReportExt
//CLASS NAME: SLARPaymentTransactionReport.cs

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
    [IDOExtensionClass("SLARPaymentTransactionReport")]
    public class SLARPaymentTransactionReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARPaymentTransactionSp([Optional] string PPaymentType,
		                                            [Optional] byte? PDisplayDetail,
		                                            [Optional] string PStartingCustomer,
		                                            [Optional] string PEndingCustomer,
		                                            [Optional] string PStartBnkCode,
		                                            [Optional] string PEndBnkCode,
		                                            [Optional] DateTime? PStartRecDate,
		                                            [Optional] DateTime? PEndRecDate,
		                                            [Optional] int? PStartChkNum,
		                                            [Optional] int? PEndChkNum,
		                                            [Optional] byte? PDisplayHeader,
		                                            [Optional] DateTime? PDepositDateStarting,
		                                            [Optional] DateTime? PDepositDateEnding,
		                                            [Optional] short? PStartRecDateOffset,
		                                            [Optional] short? PEndRecDateOffset,
		                                            [Optional] short? PDepositDateStartingOffset,
		                                            [Optional] short? PDepositDateEndingOffset,
		                                            [Optional] string PStartCrdMemNum,
		                                            [Optional] string PEndCrdMemNum,
		                                            [Optional] byte? Includenull,
		                                            [Optional] string pSite,
		                                            [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARPaymentTransactionExt = new Rpt_ARPaymentTransactionFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARPaymentTransactionExt.Rpt_ARPaymentTransactionSp(PPaymentType,
				                                                                     PDisplayDetail,
				                                                                     PStartingCustomer,
				                                                                     PEndingCustomer,
				                                                                     PStartBnkCode,
				                                                                     PEndBnkCode,
				                                                                     PStartRecDate,
				                                                                     PEndRecDate,
				                                                                     PStartChkNum,
				                                                                     PEndChkNum,
				                                                                     PDisplayHeader,
				                                                                     PDepositDateStarting,
				                                                                     PDepositDateEnding,
				                                                                     PStartRecDateOffset,
				                                                                     PEndRecDateOffset,
				                                                                     PDepositDateStartingOffset,
				                                                                     PDepositDateEndingOffset,
				                                                                     PStartCrdMemNum,
				                                                                     PEndCrdMemNum,
				                                                                     Includenull,
				                                                                     pSite,
				                                                                     BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
