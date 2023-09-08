//PROJECT NAME: ReportExt
//CLASS NAME: SLPreAssignedLotsReport.cs

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
    [IDOExtensionClass("SLPreAssignedLotsReport")]
    public class SLPreAssignedLotsReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PreAssignedLotSp([Optional] string Item,
		[Optional] string RefType,
		[Optional] string RefNum,
		[Optional] int? RefLineSuf,
		[Optional] int? RefRelease,
		[Optional] string pSite)
		{
			var iRpt_PreAssignedLotExt = new Rpt_PreAssignedLotFactory().Create(this, true);
			
			var result = iRpt_PreAssignedLotExt.Rpt_PreAssignedLotSp(Item,
			RefType,
			RefNum,
			RefLineSuf,
			RefRelease,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

    }
}
