//PROJECT NAME: MG
//CLASS NAME: SLTHAPettyCashReport.cs

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
	[IDOExtensionClass("SLTHAPettyCashReport")]
	public class SLTHAPettyCashReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_PettyCashSp([Optional] string StartingBankCode,
		[Optional] string EndingBankCode,
		[Optional] DateTime? StartingIssueDate,
		[Optional] DateTime? EndingIssueDate,
		[Optional] string StartingReference,
		[Optional] string EndingReference,
		[Optional] string pSite)
		{
			var iTHARpt_PettyCashExt = new THARpt_PettyCashFactory().Create(this, true);
			
			var result = iTHARpt_PettyCashExt.THARpt_PettyCashSp(StartingBankCode,
			EndingBankCode,
			StartingIssueDate,
			EndingIssueDate,
			StartingReference,
			EndingReference,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
