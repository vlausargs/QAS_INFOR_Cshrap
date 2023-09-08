//PROJECT NAME: Production
//CLASS NAME: ICreatePsitemReleases.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICreatePsitemReleases
	{
		(int? ReturnCode, int? Suffix,
		string Infobar) CreatePsitemReleasesSp(int? InsertFlag,
		string Job,
		int? Suffix,
		DateTime? EndDate,
		string Status,
		string OldStatus,
		decimal? QtyReleased,
		string Infobar);
	}
}

