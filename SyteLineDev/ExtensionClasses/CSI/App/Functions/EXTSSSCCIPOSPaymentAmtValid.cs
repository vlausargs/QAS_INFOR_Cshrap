//PROJECT NAME: Data
//CLASS NAME: EXTSSSCCIPOSPaymentAmtValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSCCIPOSPaymentAmtValid : IEXTSSSCCIPOSPaymentAmtValid
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSCCIPOSPaymentAmtValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Amount,
			string Infobar) EXTSSSCCIPOSPaymentAmtValidSp(
			decimal? GatewayTransNum,
			decimal? Amount,
			string Infobar)
		{
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			AmountType _Amount = Amount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSCCIPOSPaymentAmtValidSp";
				
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Amount = _Amount;
				Infobar = _Infobar;
				
				return (Severity, Amount, Infobar);
			}
		}
	}
}
