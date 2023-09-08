//PROJECT NAME: ReportExt
//CLASS NAME: SLVouchersPayableReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLVouchersPayableReport")]
    public class SLVouchersPayableReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VouchersPayableSp([Optional] string POType,
			[Optional] int? TransDomCurr,
			[Optional] int? ShowDetail,
			[Optional] DateTime? CutoffDate,
			[Optional] string PoStarting,
			[Optional] string PoEnding,
			[Optional] string VendorStarting,
			[Optional] string VendorEnding,
			[Optional] int? CutoffDateOffset,
			[Optional] int? DisplayHeader,
			[Optional] string SiteGroup,
			[Optional] string BuilderPoStarting,
			[Optional] string BuilderPoEnding,
			[Optional] int? TaskId,
			[Optional] int? PrintItemOverview,
			[Optional] string BGSessionId,
			[Optional] string pSite)
		{
            var iRpt_VouchersPayableExt = this.GetService<IRpt_VouchersPayable>();

            var result = iRpt_VouchersPayableExt.Rpt_VouchersPayableSp(POType,
			TransDomCurr,
			ShowDetail,
			CutoffDate,
			PoStarting,
			PoEnding,
			VendorStarting,
			VendorEnding,
			CutoffDateOffset,
			DisplayHeader,
			SiteGroup,
			BuilderPoStarting,
			BuilderPoEnding,
			TaskId,
			PrintItemOverview,
			BGSessionId,
			pSite);
			
			if (result.Data is null)
			return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}            
		}
    }
}
