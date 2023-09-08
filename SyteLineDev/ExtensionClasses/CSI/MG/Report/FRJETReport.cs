//PROJECT NAME: MG
//CLASS NAME: FRJETReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("FRJETReport")]
	public class FRJETReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FRJETSp(int? PYear,
		DateTime? StartDate,
		DateTime? EndDate,
		[Optional] string pSite)
		{
			var iRpt_FRJETExt = new Rpt_FRJETFactory().Create(this, true);
			
			var result = iRpt_FRJETExt.Rpt_FRJETSp(PYear,
			StartDate,
			EndDate,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
