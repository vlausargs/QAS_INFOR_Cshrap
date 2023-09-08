//PROJECT NAME: ReportExt
//CLASS NAME: JPTaxControlReport.cs

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
	[IDOExtensionClass("JPTaxControlReport")]
	public class JPTaxControlReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable JP_Rpt_TaxControlSp([Optional] int? DisplayHeader,
		[Optional] string TaxCodeStarting,
		[Optional] string TaxCodeEnding,
		[Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] string Style,
		[Optional] string pSite)
		{
			var iJP_Rpt_TaxControlExt = new JP_Rpt_TaxControlFactory().Create(this, true);
			
			var result = iJP_Rpt_TaxControlExt.JP_Rpt_TaxControlSp(DisplayHeader,
			TaxCodeStarting,
			TaxCodeEnding,
			DateStarting,
			DateEnding,
			Style,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}
