//PROJECT NAME: ReportExt
//CLASS NAME: SLCHSAPAccountBookReport.cs

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
    [IDOExtensionClass("SLCHSAPAccountBookReport")]
    public class SLCHSAPAccountBookReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_APAccountBookSp(string BegVendNum,
		string EndVendNum,
		DateTime? BegDate,
		DateTime? EndDate,
		string CurrencyCode,
		int? ViewDetailStats,
		[Optional] string pSite)
		{
			var iCHSRpt_APAccountBookExt = new CHSRpt_APAccountBookFactory().Create(this, true);
			
			var result = iCHSRpt_APAccountBookExt.CHSRpt_APAccountBookSp(BegVendNum,
			EndVendNum,
			BegDate,
			EndDate,
			CurrencyCode,
			ViewDetailStats,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

    }
}
