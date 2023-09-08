//PROJECT NAME: POS
//CLASS NAME: SSSPOSPaymentDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPaymentDefault : ISSSPOSPaymentDefault
	{
		readonly IApplicationDB appDB;
		
		
		public SSSPOSPaymentDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PayType,
		decimal? Amount,
		string Infobar) SSSPOSPaymentDefaultSp(string POSNum,
		string PayType,
		decimal? Amount,
		string Infobar)
		{
			POSMNumType _POSNum = POSNum;
			POSMPayTypeType _PayType = PayType;
			AmountType _Amount = Amount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPaymentDefaultSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PayType = _PayType;
				Amount = _Amount;
				Infobar = _Infobar;
				
				return (Severity, PayType, Amount, Infobar);
			}
		}
	}
}
