//PROJECT NAME: Codes
//CLASS NAME: IUmCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IUmCheck
	{
		(int? ReturnCode, string Infobar) UmCheckSp(string Selection,
		string OldUM,
		string NewUM,
		string Item,
		string ConvType,
		string CustVendType,
		decimal? ConvFactor,
		decimal? ConvDivisor,
		int? RptFlag,
		string Infobar);
	}
}

