//PROJECT NAME: ReportExt
//CLASS NAME: SLAccountsPayableAgingReport.cs

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
    [IDOExtensionClass("SLAccountsPayableAgingReport")]
    public class SLAccountsPayableAgingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AccountsPayableAgingSp([Optional] string VendorStarting,
		                                            [Optional] string VendorEnding,
		                                            [Optional] string NameStarting,
		                                            [Optional] string NameEnding,
		                                            [Optional] string CurrCodeStarting,
		                                            [Optional] string CurrCodeEnding,
		                                            [Optional] string SiteGroup,
		                                            [Optional] DateTime? AgingDate,
		                                            [Optional] DateTime? CutOffDate,
		                                            [Optional] byte? PrintPostTrans,
		                                            [Optional] byte? PrintOpenPaymts,
		                                            [Optional] byte? SupZeroBalVch,
		                                            [Optional] byte? TransDomCurr,
		                                            [Optional] byte? UseHistRate,
		                                            [Optional] int? AgeBucket,
		                                            [Optional] string AgingBasis,
		                                            [Optional] string PayHold,
		                                            [Optional] byte? ShowActive,
		                                            [Optional] byte? SortByCurrCode,
		                                            [Optional] byte? SortByNum,
		                                            [Optional] short? AgeDays1,
		                                            [Optional] short? AgeDays2,
		                                            [Optional] short? AgeDays3,
		                                            [Optional] short? AgeDays4,
		                                            [Optional] short? AgeDays5,
		                                            [Optional] string AgeDesc1,
		                                            [Optional] string AgeDesc2,
		                                            [Optional] string AgeDesc3,
		                                            [Optional] string AgeDesc4,
		                                            [Optional] string AgeDesc5,
		                                            [Optional] short? AgingDateOffset,
		                                            [Optional] short? CutOffDateOffset,
		                                            [Optional] byte? DisplayHeader,
		                                            [Optional] byte? ConsolidateVendors,
		                                            [Optional] int? TaskID,
		                                            [Optional] string pSite,
													[Optional] Guid? ProcessId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_AccountsPayableAgingExt = new Rpt_AccountsPayableAgingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_AccountsPayableAgingExt.Rpt_AccountsPayableAgingSp(VendorStarting,
				                                                                     VendorEnding,
				                                                                     NameStarting,
				                                                                     NameEnding,
				                                                                     CurrCodeStarting,
				                                                                     CurrCodeEnding,
				                                                                     SiteGroup,
				                                                                     AgingDate,
				                                                                     CutOffDate,
				                                                                     PrintPostTrans,
				                                                                     PrintOpenPaymts,
				                                                                     SupZeroBalVch,
				                                                                     TransDomCurr,
				                                                                     UseHistRate,
				                                                                     AgeBucket,
				                                                                     AgingBasis,
				                                                                     PayHold,
				                                                                     ShowActive,
				                                                                     SortByCurrCode,
				                                                                     SortByNum,
				                                                                     AgeDays1,
				                                                                     AgeDays2,
				                                                                     AgeDays3,
				                                                                     AgeDays4,
				                                                                     AgeDays5,
				                                                                     AgeDesc1,
				                                                                     AgeDesc2,
				                                                                     AgeDesc3,
				                                                                     AgeDesc4,
				                                                                     AgeDesc5,
				                                                                     AgingDateOffset,
				                                                                     CutOffDateOffset,
				                                                                     DisplayHeader,
				                                                                     ConsolidateVendors,
				                                                                     TaskID,
				                                                                     pSite,
																					 ProcessId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
