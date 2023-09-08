//PROJECT NAME: Logistics
//CLASS NAME: IAU_RepriceCoitemorBlanketLines.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAU_RepriceCoitemorBlanketLines
	{
		(int? ReturnCode, string Infobar) AU_RepriceCoitemorBlanketLinesSp(int? LineorBlanketLine,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? NewPrice,
		DateTime? RecordDate,
		Guid? SessionID = null,
		string ReasonText = null,
		string Infobar = null);
	}
}

