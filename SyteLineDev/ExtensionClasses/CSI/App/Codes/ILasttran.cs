//PROJECT NAME: Codes
//CLASS NAME: ILasttran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ILasttran
	{
		(int? ReturnCode, int? Success,
		string Infobar) LasttranSp(int? Key,
		decimal? LockUserid,
		int? TransLocked,
		int? Success,
		string Infobar);
	}
}

