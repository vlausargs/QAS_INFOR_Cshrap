//PROJECT NAME: Finance
//CLASS NAME: Portal_SSSCCIProcessCardWrap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_SSSCCIProcessCardWrap
	{
		(int? ReturnCode, string cardType,
		string authCode,
		decimal? GatewayTransNum,
		string Infobar,
		byte? iSuccess) Portal_SSSCCIProcessCardWrapSp(string TransType,
		string cardNum,
		string expDate,
		string NameOnCard,
		string StreetAddress,
		string City,
		string State,
		string Zip,
		string CVNum,
		string CustNum,
		int? CustSeq,
		string RefType,
		string OrdInvNum,
		decimal? ForAmt,
		decimal? ExchRate,
		decimal? TotalAmt,
		decimal? TaxAmt,
		string cardType,
		string authCode,
		decimal? GatewayTransNum,
		string Infobar,
		byte? iSuccess,
		byte? AutoPostOpenPayment,
		byte? StoreCard,
		string CustRef,
		string Username = null,
		string CardSystemId = null,
		decimal? DomAmt = null,
		decimal? PayExchRate = null,
		byte[] Signature = null);
	}
	
	public class Portal_SSSCCIProcessCardWrap : IPortal_SSSCCIProcessCardWrap
	{
		readonly IApplicationDB appDB;
		
		public Portal_SSSCCIProcessCardWrap(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string cardType,
		string authCode,
		decimal? GatewayTransNum,
		string Infobar,
		byte? iSuccess) Portal_SSSCCIProcessCardWrapSp(string TransType,
		string cardNum,
		string expDate,
		string NameOnCard,
		string StreetAddress,
		string City,
		string State,
		string Zip,
		string CVNum,
		string CustNum,
		int? CustSeq,
		string RefType,
		string OrdInvNum,
		decimal? ForAmt,
		decimal? ExchRate,
		decimal? TotalAmt,
		decimal? TaxAmt,
		string cardType,
		string authCode,
		decimal? GatewayTransNum,
		string Infobar,
		byte? iSuccess,
		byte? AutoPostOpenPayment,
		byte? StoreCard,
		string CustRef,
		string Username = null,
		string CardSystemId = null,
		decimal? DomAmt = null,
		decimal? PayExchRate = null,
		byte[] Signature = null)
		{
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
			CustSeqType _CustSeq = CustSeq;
			CCITransRefTypeType _RefType = RefType;
			InvNumType _OrdInvNum = OrdInvNum;
			AmountType _ForAmt = ForAmt;
			ExchRateType _ExchRate = ExchRate;
			AmountType _TotalAmt = TotalAmt;
			AmountType _TaxAmt = TaxAmt;
			CCICardTypeType _cardType = cardType;
			CCICharAuthCodeType _authCode = authCode;
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			Infobar _Infobar = Infobar;
			ListYesNoType _iSuccess = iSuccess;
			ListYesNoType _AutoPostOpenPayment = AutoPostOpenPayment;
			ListYesNoType _StoreCard = StoreCard;
			RefStrType _CustRef = CustRef;
			UsernameType _Username = Username;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			AmountType _DomAmt = DomAmt;
			ExchRateType _PayExchRate = PayExchRate;
			BinaryType _Signature = Signature;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_SSSCCIProcessCardWrapSp";
				
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
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdInvNum", _OrdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalAmt", _TotalAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cardType", _cardType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "authCode", _authCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iSuccess", _iSuccess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoPostOpenPayment", _AutoPostOpenPayment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StoreCard", _StoreCard, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustRef", _CustRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmt", _DomAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Signature", _Signature, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				cardType = _cardType;
				authCode = _authCode;
				GatewayTransNum = _GatewayTransNum;
				Infobar = _Infobar;
				iSuccess = _iSuccess;
				
				return (Severity, cardType, authCode, GatewayTransNum, Infobar, iSuccess);
			}
		}
	}
}
