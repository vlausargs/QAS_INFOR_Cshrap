//PROJECT NAME: Finance
//CLASS NAME: JournalGetExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalGetExchRate : IJournalGetExchRate
	{
		readonly IApplicationDB appDB;
		
		public JournalGetExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PExchRate,
			int? PFixedEuro,
			string Infobar) JournalGetExchRateSp(
			string PCurrCode,
			DateTime? TransDate,
			decimal? PExchRate,
			int? PFixedEuro,
			string Infobar)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			DateType _TransDate = TransDate;
			ExchRateType _PExchRate = PExchRate;
			Flag _PFixedEuro = PFixedEuro;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalGetExchRateSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFixedEuro", _PFixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PExchRate = _PExchRate;
				PFixedEuro = _PFixedEuro;
				Infobar = _Infobar;
				
				return (Severity, PExchRate, PFixedEuro, Infobar);
			}
		}
	}
}
