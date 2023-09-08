//PROJECT NAME: Logistics
//CLASS NAME: ArpmtGetCurrentExchangeRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtGetCurrentExchangeRate : IArpmtGetCurrentExchangeRate
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtGetCurrentExchangeRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PExchRate,
		string PInfobar) ArpmtGetCurrentExchangeRateSp(string PBankCurrCode,
		DateTime? PRecptDate,
		decimal? PExchRate,
		string PInfobar)
		{
			CurrCodeType _PBankCurrCode = PBankCurrCode;
			DateType _PRecptDate = PRecptDate;
			ExchRateType _PExchRate = PExchRate;
			InfobarType _PInfobar = PInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtGetCurrentExchangeRateSp";
				
				appDB.AddCommandParameter(cmd, "PBankCurrCode", _PBankCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInfobar", _PInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PExchRate = _PExchRate;
				PInfobar = _PInfobar;
				
				return (Severity, PExchRate, PInfobar);
			}
		}
	}
}
