//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckCOCTO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckCOCTO
	{
		(int? ReturnCode, int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar) RSQC_CheckCOCTOSp(string ToNum,
		int? ToLine,
		int? ToRelease,
		string Item,
		int? QCItem,
		int? COCItem,
		decimal? QtyCOC,
		decimal? QtyCOCPrinted,
		Guid? SessionID,
		string Infobar);
	}
}

