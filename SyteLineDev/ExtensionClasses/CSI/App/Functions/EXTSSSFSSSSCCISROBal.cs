//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSSSSCCISROBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSSSSCCISROBal : IEXTSSSFSSSSCCISROBal
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSSSSCCISROBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Balance,
			decimal? TaxAmt,
			decimal? ExchRate,
			decimal? ForAmt,
			string Infobar) EXTSSSFSSSSCCISROBalSp(
			string SroNum,
			string AuthType,
			decimal? AuthAmount,
			decimal? Balance,
			decimal? TaxAmt,
			decimal? ExchRate,
			decimal? ForAmt,
			string Infobar)
		{
			StringType _SroNum = SroNum;
			ListAmountPercentType _AuthType = AuthType;
			AmountType _AuthAmount = AuthAmount;
			AmountType _Balance = Balance;
			AmountType _TaxAmt = TaxAmt;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForAmt = ForAmt;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSSSSCCISROBalSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthType", _AuthType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthAmount", _AuthAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				TaxAmt = _TaxAmt;
				ExchRate = _ExchRate;
				ForAmt = _ForAmt;
				Infobar = _Infobar;
				
				return (Severity, Balance, TaxAmt, ExchRate, ForAmt, Infobar);
			}
		}
	}
}
