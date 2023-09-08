//PROJECT NAME: ReportExt
//CLASS NAME: CHSUnpostedSystemVoucherReport.cs

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
    [IDOExtensionClass("CHSUnpostedSystemVoucherReport")]
    public class CHSUnpostedSystemVoucherReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_ManualVoucherPrintSp(short? FiscalYear,
		                                             byte? Period,
		                                             string CrntNmbrStart,
		                                             string CrntNmbrEnd,
		                                             string TypeCode,
		                                             DateTime? TransDate,
		                                             [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_ManualVoucherPrintExt = new CHSRpt_ManualVoucherPrintFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_ManualVoucherPrintExt.CHSRpt_ManualVoucherPrintSp(FiscalYear,
				                                                                       Period,
				                                                                       CrntNmbrStart,
				                                                                       CrntNmbrEnd,
				                                                                       TypeCode,
				                                                                       TransDate,
				                                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_PostedVoucherInquirySp(DateTime? TransDate,
		                                               byte? Period,
		                                               string CrntNmbrStart,
		                                               string CrntNmbrEnd,
		                                               string TypeCode,
		                                               [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_PostedVoucherInquiryExt = new CHSRpt_PostedVoucherInquiryFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_PostedVoucherInquiryExt.CHSRpt_PostedVoucherInquirySp(TransDate,
				                                                                           Period,
				                                                                           CrntNmbrStart,
				                                                                           CrntNmbrEnd,
				                                                                           TypeCode,
				                                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_PostedVoucherTransactionInquirySp(string SessionId,
		                                                          [Optional] string pLanguage,
		                                                          [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_PostedVoucherTransactionInquiryExt = new CHSRpt_PostedVoucherTransactionInquiryFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_PostedVoucherTransactionInquiryExt.CHSRpt_PostedVoucherTransactionInquirySp(SessionId,
				                                                                                                 pLanguage,
				                                                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_SystemVoucherPrintSp(short? FiscalYear,
		                                             byte? Period,
		                                             string CrntNmbrStart,
		                                             string CrntNmbrEnd,
		                                             string JournalID,
		                                             byte? ReadOnly,
		                                             DateTime? TransDate,
		                                             [Optional] string pLanguage,
		                                             [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_SystemVoucherPrintExt = new CHSRpt_SystemVoucherPrintFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_SystemVoucherPrintExt.CHSRpt_SystemVoucherPrintSp(FiscalYear,
				                                                                       Period,
				                                                                       CrntNmbrStart,
				                                                                       CrntNmbrEnd,
				                                                                       JournalID,
				                                                                       ReadOnly,
				                                                                       TransDate,
				                                                                       pLanguage,
				                                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
