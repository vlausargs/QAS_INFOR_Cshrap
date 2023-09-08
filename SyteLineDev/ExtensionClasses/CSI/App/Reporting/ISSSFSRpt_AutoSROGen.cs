//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_AutoSROGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_AutoSROGen
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_AutoSROGenSp(int? iCreateSROs,
		DateTime? iThroughDate,
		string iStartSerNum,
		string iEndSerNum,
		string iStartSroType,
		string iEndSroType,
		string iStartDept,
		string iEndDept,
		string iStartWc,
		string iEndWc,
		int? iKeepOperNums,
		int? iDateOffset,
		string pSite = null,
		decimal? UserID = null);
	}
}

