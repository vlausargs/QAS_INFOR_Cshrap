//PROJECT NAME: Logistics
//CLASS NAME: ITranUd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITranUd
	{
		(int? ReturnCode, decimal? LastTran,
		string Infobar) TranUdSp(int? LasttranKey,
		decimal? LastTran,
		string Infobar);
	}
}

