//PROJECT NAME: Finance
//CLASS NAME: SSSCCIProcessCardExternal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIProcessCardExternal : ISSSCCIProcessCardExternal
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIProcessCardExternal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Last4 = null)
		{
			CCICardSystemType _CardSystem = CardSystem;
			CCITransTypeType _TransType = TransType;
			StringType _cardNum = cardNum;
			StringType _expDate = expDate;
			StringType _NameOnCard = NameOnCard;
			StringType _StreetAddress = StreetAddress;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CCICVNumType _CVNum = CVNum;
			CustNumType _CustNum = CustNum;
			CCITransRefTypeType _RefType = RefType;
			InvNumType _OrdInvNum = OrdInvNum;
			AmountType _TotalAmt = TotalAmt;
			AmountType _TaxAmt = TaxAmt;
			ListYesNoType _NewOrder = NewOrder;
			AmountType _OrigTotalAmt = OrigTotalAmt;
			AmountType _ForAmt = ForAmt;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _AutoPostOpenPayment = AutoPostOpenPayment;
			RefStrType _CustRef = CustRef;
			CCIGatewayLongTransNumType _GatewayLongTransNum = GatewayLongTransNum;
			RowPointerType _AuthBatchID = AuthBatchID;
			CCICharAuthCodeType _AuthCode = AuthCode;
			ListYesNoType _StoreCard = StoreCard;
			CCICardTypeType _CardType = CardType;
			LongDescType _GatewayStoredToken = GatewayStoredToken;
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			InfobarType _Infobar = Infobar;
			ListYesNoType _iSuccess = iSuccess;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			AmountType _DomAmt = DomAmt;
			ExchRateType _PayExchRate = PayExchRate;
			BinaryType _Signature = Signature;
			CCICardLast4DigitsType _Last4 = Last4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIProcessCardExternalSp";
				
				appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cardNum", _cardNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "expDate", _expDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameOnCard", _NameOnCard, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StreetAddress", _StreetAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CVNum", _CVNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdInvNum", _OrdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalAmt", _TotalAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewOrder", _NewOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigTotalAmt", _OrigTotalAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoPostOpenPayment", _AutoPostOpenPayment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustRef", _CustRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayLongTransNum", _GatewayLongTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthBatchID", _AuthBatchID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthCode", _AuthCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StoreCard", _StoreCard, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CardType", _CardType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GatewayStoredToken", _GatewayStoredToken, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iSuccess", _iSuccess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmt", _DomAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Signature", _Signature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Last4", _Last4, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StoreCard = _StoreCard;
				CardType = _CardType;
				GatewayStoredToken = _GatewayStoredToken;
				GatewayTransNum = _GatewayTransNum;
				Infobar = _Infobar;
				iSuccess = _iSuccess;
				
				return (Severity, StoreCard, CardType, GatewayStoredToken, GatewayTransNum, Infobar, iSuccess);
			}
		}
	}
}
