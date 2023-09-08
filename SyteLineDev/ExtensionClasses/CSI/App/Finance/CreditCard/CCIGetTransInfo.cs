//PROJECT NAME: Finance
//CLASS NAME: CCIGetTransInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class CCIGetTransInfo : ICCIGetTransInfo
	{
		readonly IApplicationDB appDB;
		
		
		public CCIGetTransInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string GatewayStoredToken,
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
		string Infobar)
		{
			CCICardSystemIDType _CardSystemId = CardSystemId;
			CCICardSystemType _CardSystem = CardSystem;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			CCITransRefTypeType _RefType = RefType;
			CCITransTypeType _TransType = TransType;
			InvNumType _OrdInvNum = OrdInvNum;
			LongDescType _GatewayStoredToken = GatewayStoredToken;
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			CCICardLast4DigitsType _CardLast4Digits = CardLast4Digits;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CCIGetTransInfoSp";
				
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdInvNum", _OrdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayStoredToken", _GatewayStoredToken, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CardLast4Digits", _CardLast4Digits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GatewayStoredToken = _GatewayStoredToken;
				GatewayTransNum = _GatewayTransNum;
				CardLast4Digits = _CardLast4Digits;
				Infobar = _Infobar;
				
				return (Severity, GatewayStoredToken, GatewayTransNum, CardLast4Digits, Infobar);
			}
		}
	}
}
