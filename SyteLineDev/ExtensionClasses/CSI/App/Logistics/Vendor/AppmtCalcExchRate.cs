//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcExchRate : IAppmtCalcExchRate
	{
		readonly IApplicationDB appDB;
		
		public AppmtCalcExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PExchRate) AppmtCalcExchRateSp(
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
				cmd.CommandText = "AppmtCalcExchRateSp";
				
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
