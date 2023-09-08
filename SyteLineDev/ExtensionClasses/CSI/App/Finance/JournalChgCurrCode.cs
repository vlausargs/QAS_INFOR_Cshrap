//PROJECT NAME: CSIFinance
//CLASS NAME: JournalChgCurrCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IJournalChgCurrCode
	{
		int JournalChgCurrCodeSp(string PCurrCode,
		                         ref decimal? PDomAmtDr,
		                         ref decimal? PDomAmtCr,
		                         DateTime? TransDate,
		                         ref decimal? PExchRate,
		                         ref byte? PFixedEuro,
		                         decimal? PForAmtDr,
		                         decimal? PForAmtCr,
		                         ref string Infobar);
	}
	
	public class JournalChgCurrCode : IJournalChgCurrCode
	{
		readonly IApplicationDB appDB;
		
		public JournalChgCurrCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int JournalChgCurrCodeSp(string PCurrCode,
		                                ref decimal? PDomAmtDr,
		                                ref decimal? PDomAmtCr,
		                                DateTime? TransDate,
		                                ref decimal? PExchRate,
		                                ref byte? PFixedEuro,
		                                decimal? PForAmtDr,
		                                decimal? PForAmtCr,
		                                ref string Infobar)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			AmountType _PDomAmtDr = PDomAmtDr;
			AmountType _PDomAmtCr = PDomAmtCr;
			DateType _TransDate = TransDate;
			ExchRateType _PExchRate = PExchRate;
			Flag _PFixedEuro = PFixedEuro;
			AmountType _PForAmtDr = PForAmtDr;
			AmountType _PForAmtCr = PForAmtCr;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalChgCurrCodeSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmtDr", _PDomAmtDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomAmtCr", _PDomAmtCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFixedEuro", _PFixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForAmtDr", _PForAmtDr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtCr", _PForAmtCr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDomAmtDr = _PDomAmtDr;
				PDomAmtCr = _PDomAmtCr;
				PExchRate = _PExchRate;
				PFixedEuro = _PFixedEuro;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
