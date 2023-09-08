//PROJECT NAME: CSICCI
//CLASS NAME: SSSCCIParmsInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIParmsInfo
	{
		int SSSCCIParmsInfoSp(string CardSystemId,
		                      ref string UserName,
		                      ref string Password,
		                      ref string PaymentSvr,
		                      ref byte? AutoPostOpenPayment,
		                      ref string CardSystem,
		                      ref byte? PurchaseAuth,
		                      ref string GatewayVendID,
		                      ref string DBName,
		                      ref string ServerName,
		                      ref string CurrCode);
	}
	
	public class SSSCCIParmsInfo : ISSSCCIParmsInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIParmsInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSCCIParmsInfoSp(string CardSystemId,
		                             ref string UserName,
		                             ref string Password,
		                             ref string PaymentSvr,
		                             ref byte? AutoPostOpenPayment,
		                             ref string CardSystem,
		                             ref byte? PurchaseAuth,
		                             ref string GatewayVendID,
		                             ref string DBName,
		                             ref string ServerName,
		                             ref string CurrCode)
		{
			CCICardSystemIDType _CardSystemId = CardSystemId;
			UsernameType _UserName = UserName;
			PasswordType _Password = Password;
			URLType _PaymentSvr = PaymentSvr;
			ListYesNoType _AutoPostOpenPayment = AutoPostOpenPayment;
			CCICardSystemType _CardSystem = CardSystem;
			ListYesNoType _PurchaseAuth = PurchaseAuth;
			CCIGatewayVendIdType _GatewayVendID = GatewayVendID;
			OSLocationType _DBName = DBName;
			OSLocationType _ServerName = ServerName;
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIParmsInfoSp";
				
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentSvr", _PaymentSvr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoPostOpenPayment", _AutoPostOpenPayment, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PurchaseAuth", _PurchaseAuth, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GatewayVendID", _GatewayVendID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DBName", _DBName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ServerName", _ServerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UserName = _UserName;
				Password = _Password;
				PaymentSvr = _PaymentSvr;
				AutoPostOpenPayment = _AutoPostOpenPayment;
				CardSystem = _CardSystem;
				PurchaseAuth = _PurchaseAuth;
				GatewayVendID = _GatewayVendID;
				DBName = _DBName;
				ServerName = _ServerName;
				CurrCode = _CurrCode;
				
				return Severity;
			}
		}
	}
}
