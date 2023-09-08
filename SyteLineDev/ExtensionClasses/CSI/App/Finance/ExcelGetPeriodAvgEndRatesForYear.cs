//PROJECT NAME: Finance
//CLASS NAME: ExcelGetPeriodAvgEndRatesForYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ExcelGetPeriodAvgEndRatesForYear : IExcelGetPeriodAvgEndRatesForYear
	{
		readonly IApplicationDB appDB;
		
		
		public ExcelGetPeriodAvgEndRatesForYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PAvgRate01,
		decimal? PEndRate01,
		decimal? PAvgRate02,
		decimal? PEndRate02,
		decimal? PAvgRate03,
		decimal? PEndRate03,
		decimal? PAvgRate04,
		decimal? PEndRate04,
		decimal? PAvgRate05,
		decimal? PEndRate05,
		decimal? PAvgRate06,
		decimal? PEndRate06,
		decimal? PAvgRate07,
		decimal? PEndRate07,
		decimal? PAvgRate08,
		decimal? PEndRate08,
		decimal? PAvgRate09,
		decimal? PEndRate09,
		decimal? PAvgRate10,
		decimal? PEndRate10,
		decimal? PAvgRate11,
		decimal? PEndRate11,
		decimal? PAvgRate12,
		decimal? PEndRate12,
		decimal? PAvgRate13,
		decimal? PEndRate13,
		decimal? PCurrentRate,
		string Infobar) ExcelGetPeriodAvgEndRatesForYearSp(string PSite = null,
		string PFromCurrCode = null,
		string PToCurrCode = null,
		int? PUseBuyRate = 1,
		int? PFiscalYear = null,
		decimal? PAvgRate01 = null,
		decimal? PEndRate01 = null,
		decimal? PAvgRate02 = null,
		decimal? PEndRate02 = null,
		decimal? PAvgRate03 = null,
		decimal? PEndRate03 = null,
		decimal? PAvgRate04 = null,
		decimal? PEndRate04 = null,
		decimal? PAvgRate05 = null,
		decimal? PEndRate05 = null,
		decimal? PAvgRate06 = null,
		decimal? PEndRate06 = null,
		decimal? PAvgRate07 = null,
		decimal? PEndRate07 = null,
		decimal? PAvgRate08 = null,
		decimal? PEndRate08 = null,
		decimal? PAvgRate09 = null,
		decimal? PEndRate09 = null,
		decimal? PAvgRate10 = null,
		decimal? PEndRate10 = null,
		decimal? PAvgRate11 = null,
		decimal? PEndRate11 = null,
		decimal? PAvgRate12 = null,
		decimal? PEndRate12 = null,
		decimal? PAvgRate13 = null,
		decimal? PEndRate13 = null,
		decimal? PCurrentRate = null,
		string Infobar = null)
		{
			SiteType _PSite = PSite;
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			CurrCodeType _PToCurrCode = PToCurrCode;
			ListBuySellType _PUseBuyRate = PUseBuyRate;
			FiscalYearType _PFiscalYear = PFiscalYear;
			ExchRateType _PAvgRate01 = PAvgRate01;
			ExchRateType _PEndRate01 = PEndRate01;
			ExchRateType _PAvgRate02 = PAvgRate02;
			ExchRateType _PEndRate02 = PEndRate02;
			ExchRateType _PAvgRate03 = PAvgRate03;
			ExchRateType _PEndRate03 = PEndRate03;
			ExchRateType _PAvgRate04 = PAvgRate04;
			ExchRateType _PEndRate04 = PEndRate04;
			ExchRateType _PAvgRate05 = PAvgRate05;
			ExchRateType _PEndRate05 = PEndRate05;
			ExchRateType _PAvgRate06 = PAvgRate06;
			ExchRateType _PEndRate06 = PEndRate06;
			ExchRateType _PAvgRate07 = PAvgRate07;
			ExchRateType _PEndRate07 = PEndRate07;
			ExchRateType _PAvgRate08 = PAvgRate08;
			ExchRateType _PEndRate08 = PEndRate08;
			ExchRateType _PAvgRate09 = PAvgRate09;
			ExchRateType _PEndRate09 = PEndRate09;
			ExchRateType _PAvgRate10 = PAvgRate10;
			ExchRateType _PEndRate10 = PEndRate10;
			ExchRateType _PAvgRate11 = PAvgRate11;
			ExchRateType _PEndRate11 = PEndRate11;
			ExchRateType _PAvgRate12 = PAvgRate12;
			ExchRateType _PEndRate12 = PEndRate12;
			ExchRateType _PAvgRate13 = PAvgRate13;
			ExchRateType _PEndRate13 = PEndRate13;
			ExchRateType _PCurrentRate = PCurrentRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExcelGetPeriodAvgEndRatesForYearSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurrCode", _PToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseBuyRate", _PUseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFiscalYear", _PFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgRate01", _PAvgRate01, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate01", _PEndRate01, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate02", _PAvgRate02, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate02", _PEndRate02, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate03", _PAvgRate03, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate03", _PEndRate03, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate04", _PAvgRate04, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate04", _PEndRate04, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate05", _PAvgRate05, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate05", _PEndRate05, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate06", _PAvgRate06, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate06", _PEndRate06, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate07", _PAvgRate07, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate07", _PEndRate07, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate08", _PAvgRate08, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate08", _PEndRate08, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate09", _PAvgRate09, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate09", _PEndRate09, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate10", _PAvgRate10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate10", _PEndRate10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate11", _PAvgRate11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate11", _PEndRate11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate12", _PAvgRate12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate12", _PEndRate12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAvgRate13", _PAvgRate13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndRate13", _PEndRate13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrentRate", _PCurrentRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAvgRate01 = _PAvgRate01;
				PEndRate01 = _PEndRate01;
				PAvgRate02 = _PAvgRate02;
				PEndRate02 = _PEndRate02;
				PAvgRate03 = _PAvgRate03;
				PEndRate03 = _PEndRate03;
				PAvgRate04 = _PAvgRate04;
				PEndRate04 = _PEndRate04;
				PAvgRate05 = _PAvgRate05;
				PEndRate05 = _PEndRate05;
				PAvgRate06 = _PAvgRate06;
				PEndRate06 = _PEndRate06;
				PAvgRate07 = _PAvgRate07;
				PEndRate07 = _PEndRate07;
				PAvgRate08 = _PAvgRate08;
				PEndRate08 = _PEndRate08;
				PAvgRate09 = _PAvgRate09;
				PEndRate09 = _PEndRate09;
				PAvgRate10 = _PAvgRate10;
				PEndRate10 = _PEndRate10;
				PAvgRate11 = _PAvgRate11;
				PEndRate11 = _PEndRate11;
				PAvgRate12 = _PAvgRate12;
				PEndRate12 = _PEndRate12;
				PAvgRate13 = _PAvgRate13;
				PEndRate13 = _PEndRate13;
				PCurrentRate = _PCurrentRate;
				Infobar = _Infobar;
				
				return (Severity, PAvgRate01, PEndRate01, PAvgRate02, PEndRate02, PAvgRate03, PEndRate03, PAvgRate04, PEndRate04, PAvgRate05, PEndRate05, PAvgRate06, PEndRate06, PAvgRate07, PEndRate07, PAvgRate08, PEndRate08, PAvgRate09, PEndRate09, PAvgRate10, PEndRate10, PAvgRate11, PEndRate11, PAvgRate12, PEndRate12, PAvgRate13, PEndRate13, PCurrentRate, Infobar);
			}
		}
	}
}
