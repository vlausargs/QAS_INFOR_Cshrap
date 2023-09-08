//PROJECT NAME: Finance
//CLASS NAME: IPortal_CCILogTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCILogTrans
	{
		(int? ReturnCode, string Infobar) Portal_CCILogTransSp(string CustNum,
		decimal? GatewayTransNum,
		string authCode,
		string TransType,
		decimal? TotalAmt,
		int? iSuccess,
		string RefType,
		string OrdInvNum,
		string CardType,
		string strResponseMsg,
		string CardSystem,
		decimal? ForAmt,
		decimal? ExchRate,
		int? AutoPostOpenPmt,
		decimal? GatewayLongTransNum,
		string GatewayStoredToken,
		string CustRef,
		string BackEndUserName,
		Guid? AuthBatchID,
		string ExpDate,
		string Last4,
		string Infobar,
		string CardSystemId,
		decimal? DomAmt,
		decimal? PayExchRate);
	}
}

