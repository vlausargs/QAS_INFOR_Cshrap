//PROJECT NAME: Finance
//CLASS NAME: ICCIGetTransInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ICCIGetTransInfo
	{
		(int? ReturnCode, string GatewayStoredToken,
		decimal? GatewayTransNum,
		string CardLast4Digits,
		string Infobar) CCIGetTransInfoSp(string CardSystemId,
		string CardSystem,
		string CustNum,
		int? CustSeq,
		string RefType,
		string TransType,
		string OrdInvNum,
		string GatewayStoredToken,
		decimal? GatewayTransNum,
		string CardLast4Digits,
		string Infobar);
	}
}

