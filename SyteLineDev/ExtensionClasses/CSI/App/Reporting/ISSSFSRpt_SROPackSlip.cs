//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROPackSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROPackSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPackSlipSp(int? BegPackNum = null,
		int? EndPackNum = null,
		int? BegPackSeq = null,
		int? EndPackSeq = null,
		string BegCustNum = null,
		string EndCustNum = null,
		int? PrintSerials = 0,
		int? PrintPckHdrNotes = 0,
		int? PrintPckLineNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		DateTime? BegPackDate = null,
		DateTime? EndPackDate = null,
		int? PrintSROOperNotes = 0,
		int? PrintSROLineNotes = 0,
		int? DisplayHeader = 0,
		int? PrintSRONotes = 0,
		string pSite = null);
	}
}

