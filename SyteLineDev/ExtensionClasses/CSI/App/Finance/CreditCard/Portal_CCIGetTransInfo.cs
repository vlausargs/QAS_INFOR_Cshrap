//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCIGetTransInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCIGetTransInfo
	{
		int Portal_CCIGetTransInfoSp(string CardSystemId,
		                             string CardSystem,
		                             string CustNum,
		                             int? CustSeq,
		                             string RefType,
		                             string TransType,
		                             string OrdInvNum,
		                             ref string GatewayStoredToken,
		                             ref decimal? GatewayTransNum,
		                             ref string CardLast4Digits,
		                             ref string Infobar);
	}
	
	public class Portal_CCIGetTransInfo : IPortal_CCIGetTransInfo
	{
		readonly IApplicationDB appDB;
		
		public Portal_CCIGetTransInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Portal_CCIGetTransInfoSp(string CardSystemId,
		                                    string CardSystem,
		                                    string CustNum,
		                                    int? CustSeq,
		                                    string RefType,
		                                    string TransType,
		                                    string OrdInvNum,
		                                    ref string GatewayStoredToken,
		                                    ref decimal? GatewayTransNum,
		                                    ref string CardLast4Digits,
		                                    ref string Infobar)
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
				cmd.CommandText = "Portal_CCIGetTransInfoSp";
				
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
				
				return Severity;
			}
		}
	}
}
