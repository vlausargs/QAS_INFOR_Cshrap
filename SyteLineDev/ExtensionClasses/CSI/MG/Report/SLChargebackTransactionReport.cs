//PROJECT NAME: ReportExt
//CLASS NAME: SLChargebackTransactionReport.cs

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
    [IDOExtensionClass("SLChargebackTransactionReport")]
    public class SLChargebackTransactionReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ChargebackTransactionSp([Optional] string CustomerNumStarting,
		                                             [Optional] string CustomerNumEnding,
		                                             [Optional] int? CheckNumStarting,
		                                             [Optional] int? CheckNumEnding,
		                                             [Optional] string InvNumStarting,
		                                             [Optional] string InvNumEnding,
		                                             [Optional] string ChargebackTypeStarting,
		                                             [Optional] string ChargebackTypeEnding,
		                                             [Optional] DateTime? PostedDateStarting,
		                                             [Optional] DateTime? PostedDateEnding,
		                                             [Optional] short? PostedDateStartingOffset,
		                                             [Optional] short? PostedDateEndingOffset,
		                                             [Optional, DefaultParameterValue((byte)1)] byte? PrintApprovedChargeback,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintDeinedChargeback,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintPendingChargeback,
		[Optional, DefaultParameterValue("C")] string Sortby,
		[Optional, DefaultParameterValue((byte)1)] byte? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ChargebackTransactionExt = new Rpt_ChargebackTransactionFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ChargebackTransactionExt.Rpt_ChargebackTransactionSp(CustomerNumStarting,
				                                                                       CustomerNumEnding,
				                                                                       CheckNumStarting,
				                                                                       CheckNumEnding,
				                                                                       InvNumStarting,
				                                                                       InvNumEnding,
				                                                                       ChargebackTypeStarting,
				                                                                       ChargebackTypeEnding,
				                                                                       PostedDateStarting,
				                                                                       PostedDateEnding,
				                                                                       PostedDateStartingOffset,
				                                                                       PostedDateEndingOffset,
				                                                                       PrintApprovedChargeback,
				                                                                       PrintDeinedChargeback,
				                                                                       PrintPendingChargeback,
				                                                                       Sortby,
				                                                                       PDisplayHeader,
				                                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
