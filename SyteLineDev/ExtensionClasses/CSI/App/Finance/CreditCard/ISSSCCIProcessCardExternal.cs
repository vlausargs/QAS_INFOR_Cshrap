//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIProcessCardExternal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIProcessCardExternal
	{
		(int? ReturnCode,
			int? StoreCard,
			string CardType,
			string GatewayStoredToken,
			decimal? GatewayTransNum,
			string Infobar,
			int? iSuccess) SSSCCIProcessCardExternalSp(
			string CardSystem,
			string TransType,
			string cardNum,
			string expDate,
			string NameOnCard,
			string StreetAddress,
			string City,
			string State,
			string Zip,
			string CVNum,
			string CustNum,
			string RefType,
			string OrdInvNum,
			decimal? TotalAmt,
			decimal? TaxAmt,
			int? NewOrder,
			decimal? OrigTotalAmt,
			decimal? ForAmt,
			decimal? ExchRate,
			int? AutoPostOpenPayment,
			string CustRef,
			decimal? GatewayLongTransNum,
			Guid? AuthBatchID,
			string AuthCode,
			int? StoreCard,
			string CardType,
			string GatewayStoredToken,
			decimal? GatewayTransNum,
			string Infobar,
			int? iSuccess,
			string CardSystemId,
			decimal? DomAmt,
			decimal? PayExchRate,
			byte[] Signature = null,
			string Last4 = null);
	}
}

