//PROJECT NAME: Production
//CLASS NAME: IPsitemEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPsitemEndDate
	{
		(int? ReturnCode, DateTime? PEndDate,
		decimal? PEndTick,
		string Infobar) PsitemEndDateSp(string PPsNum,
		string PItem,
		string PPsJob,
		DateTime? PEndDate,
		decimal? PEndTick,
		string Infobar);
	}
}

