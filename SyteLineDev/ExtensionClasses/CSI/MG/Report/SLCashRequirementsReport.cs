//PROJECT NAME: ReportExt
//CLASS NAME: SLCashRequirementsReport.cs

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
    [IDOExtensionClass("SLCashRequirementsReport")]
    public class SLCashRequirementsReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CashRequirementsSp([Optional] string ExOptszSiteGroup,
		                                        [Optional] DateTime? ExHbegDueDate,
		                                        [Optional] DateTime? ExEndDueDate,
		                                        [Optional] string ExHbegVendNum,
		                                        [Optional] string ExEndVendNum,
		                                        [Optional] string ExHbegName,
		                                        [Optional] string ExEndName,
		                                        [Optional] DateTime? ExOptprPaymentDate,
		                                        [Optional] byte? ExOptszSupZeroNetDue,
		                                        [Optional] byte? ExOptprPrOpenPay,
		                                        [Optional] byte? ExOptszSubByMonth,
		                                        [Optional] byte? ETransDomCurr,
		                                        [Optional] string PExOptprPayHold,
		                                        [Optional] short? CashDateStartingOffset,
		                                        [Optional] short? CashDateEndingOffset,
		                                        [Optional] short? DateOffset,
		                                        [Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CashRequirementsExt = new Rpt_CashRequirementsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CashRequirementsExt.Rpt_CashRequirementsSp(ExOptszSiteGroup,
				                                                             ExHbegDueDate,
				                                                             ExEndDueDate,
				                                                             ExHbegVendNum,
				                                                             ExEndVendNum,
				                                                             ExHbegName,
				                                                             ExEndName,
				                                                             ExOptprPaymentDate,
				                                                             ExOptszSupZeroNetDue,
				                                                             ExOptprPrOpenPay,
				                                                             ExOptszSubByMonth,
				                                                             ETransDomCurr,
				                                                             PExOptprPayHold,
				                                                             CashDateStartingOffset,
				                                                             CashDateEndingOffset,
				                                                             DateOffset,
				                                                             DisplayHeader,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
