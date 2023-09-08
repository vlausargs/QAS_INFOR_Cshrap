//PROJECT NAME: ReportExt
//CLASS NAME: CHSVoucherTotalReport.cs

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
    [IDOExtensionClass("CHSVoucherTotalReport")]
    public class CHSVoucherTotalReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_VoucherTotalSp(DateTime? BegDate,
		                                       DateTime? EndDate,
		                                       string BegCHVounum,
		                                       string EndCHVounum,
		                                       [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_VoucherTotalExt = new CHSRpt_VoucherTotalFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_VoucherTotalExt.CHSRpt_VoucherTotalSp(BegDate,
				                                                           EndDate,
				                                                           BegCHVounum,
				                                                           EndCHVounum,
				                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
