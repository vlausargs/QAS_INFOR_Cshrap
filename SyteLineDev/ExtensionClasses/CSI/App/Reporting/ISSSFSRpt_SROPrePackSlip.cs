//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROPrePackSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROPrePackSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPrePackSlipSp(string BegSroNum = null,
		string EndSroNum = null,
		int? BegSroLine = null,
		int? EndSroLine = null,
		int? BegSroOper = null,
		int? EndSroOper = null,
		string BegCustNum = null,
		string EndCustNum = null,
		DateTime? BegOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? BegTransDate = null,
		DateTime? EndTransDate = null,
		DateTime? PackDate = null,
		int? InclOpen = 1,
		int? InclInvoice = 1,
		int? InclClosed = 1,
		int? PrintSerials = 0,
		int? PrintSroNotes = 0,
		int? PrintLineNotes = 0,
		int? PrintOperNotes = 0,
		int? PrintTransNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		string ShipToAddress = "C",
		string pSite = null);
	}
}

