//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPaymentDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPaymentDefault
	{
		(int? ReturnCode, string PayType,
		decimal? Amount,
		string Infobar) SSSPOSPaymentDefaultSp(string POSNum,
		string PayType,
		decimal? Amount,
		string Infobar);
	}
}

