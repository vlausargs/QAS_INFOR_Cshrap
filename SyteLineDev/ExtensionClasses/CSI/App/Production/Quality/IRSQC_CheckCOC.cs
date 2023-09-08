//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckCOC
	{
		(int? ReturnCode, int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar) RSQC_CheckCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar);
	}
}

