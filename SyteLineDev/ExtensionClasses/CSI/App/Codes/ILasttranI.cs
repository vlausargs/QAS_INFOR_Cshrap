//PROJECT NAME: Codes
//CLASS NAME: ILasttranI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ILasttranI
	{
		(int? ReturnCode, decimal? LasttranLastTran,
		string Infobar) LasttranISp(int? LasttranKey,
		string Action,
		decimal? LasttranLastTran,
		string Infobar);
	}
}

