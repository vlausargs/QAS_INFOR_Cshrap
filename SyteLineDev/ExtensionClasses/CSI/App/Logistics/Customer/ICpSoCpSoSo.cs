//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoSo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoSo
	{
		(int? ReturnCode, decimal? POrderBal,
		string Infobar) CpSoCpSoSoSp(string PCoNum,
		int? TPlaces,
		decimal? POrderBal,
		string Infobar);
	}
}

