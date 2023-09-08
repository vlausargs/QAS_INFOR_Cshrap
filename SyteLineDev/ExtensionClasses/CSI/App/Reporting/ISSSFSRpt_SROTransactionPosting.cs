//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROTransactionPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROTransactionPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROTransactionPostingSp(Guid? SessionID,
		string GenerateReport = "A",
		string OrderBy = "S",
		decimal? TaskID = null,
		string pSite = null);
	}
}

