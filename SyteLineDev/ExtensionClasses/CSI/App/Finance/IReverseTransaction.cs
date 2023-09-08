//PROJECT NAME: Finance
//CLASS NAME: IReverseTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IReverseTransaction
	{
		(int? ReturnCode, string Infobar) ReverseTransactionSp(string PReverseTransactionType = null,
		string Pcontrol_prefix = null,
		string Pcontrol_site = null,
		int? Pcontrol_year = null,
		int? Pcontrol_period = null,
		decimal? Pcontrol_number = null,
		decimal? PUserId = null,
		string GLVoucher = null,
		string Infobar = null);
	}
}

