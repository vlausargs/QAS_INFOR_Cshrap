//PROJECT NAME: Finance
//CLASS NAME: Portal_CCILogTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCILogTrans : IPortal_CCILogTrans
	{
		readonly IApplicationDB appDB;
		
		
		public Portal_CCILogTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) Portal_CCILogTransSp(string CustNum,
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
		decimal? PayExchRate)
		{
			CustNumType _CustNum = CustNum;
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			CCICharAuthCodeType _authCode = authCode;
			CCITransTypeType _TransType = TransType;
			AmountType _TotalAmt = TotalAmt;
			ListYesNoType _iSuccess = iSuccess;
			CCITransRefTypeType _RefType = RefType;
			InvNumType _OrdInvNum = OrdInvNum;
			CCICardTypeType _CardType = CardType;
			InfobarType _strResponseMsg = strResponseMsg;
			CCICardSystemType _CardSystem = CardSystem;
			AmountType _ForAmt = ForAmt;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _AutoPostOpenPmt = AutoPostOpenPmt;
			CCIGatewayLongTransNumType _GatewayLongTransNum = GatewayLongTransNum;
			LongDescType _GatewayStoredToken = GatewayStoredToken;
			RefStrType _CustRef = CustRef;
			UsernameType _BackEndUserName = BackEndUserName;
			RowPointerType _AuthBatchID = AuthBatchID;
			CCIExpDateType _ExpDate = ExpDate;
			CCICardLast4DigitsType _Last4 = Last4;
			InfobarType _Infobar = Infobar;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			AmountType _DomAmt = DomAmt;
			ExchRateType _PayExchRate = PayExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCILogTransSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "authCode", _authCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalAmt", _TotalAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSuccess", _iSuccess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdInvNum", _OrdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardType", _CardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "strResponseMsg", _strResponseMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoPostOpenPmt", _AutoPostOpenPmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayLongTransNum", _GatewayLongTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayStoredToken", _GatewayStoredToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustRef", _CustRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackEndUserName", _BackEndUserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthBatchID", _AuthBatchID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpDate", _ExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Last4", _Last4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmt", _DomAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayExchRate", _PayExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
