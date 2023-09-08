//PROJECT NAME: Finance
//CLASS NAME: ArpmtCalcExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtCalcExchRate : IArpmtCalcExchRate
	{
		readonly IApplicationDB appDB;
		
		public ArpmtCalcExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PExchRate) ArpmtCalcExchRateSp(
			string PCurrCode,
			decimal? PDomAmt,
			decimal? PForAmt,
			decimal? PExchRate)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			AmountType _PDomAmt = PDomAmt;
			AmountType _PForAmt = PForAmt;
			ExchRateType _PExchRate = PExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtCalcExchRateSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmt", _PDomAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmt", _PForAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PExchRate = _PExchRate;
				
				return (Severity, PExchRate);
			}
		}
	}
}
