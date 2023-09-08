//PROJECT NAME: CSIFinance
//CLASS NAME: CheckFiscalYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface ICheckFiscalYear
	{
		int CheckFiscalYearSp(int? NewFiscalYear,
		                      ref int? MaxFiscalYear,
		                      ref int? MinFiscalYear,
		                      ref string Infobar);
	}
	
	public class CheckFiscalYear : ICheckFiscalYear
	{
		readonly IApplicationDB appDB;
		
		public CheckFiscalYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckFiscalYearSp(int? NewFiscalYear,
		                             ref int? MaxFiscalYear,
		                             ref int? MinFiscalYear,
		                             ref string Infobar)
		{
			IntType _NewFiscalYear = NewFiscalYear;
			IntType _MaxFiscalYear = MaxFiscalYear;
			IntType _MinFiscalYear = MinFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckFiscalYearSp";
				
				appDB.AddCommandParameter(cmd, "NewFiscalYear", _NewFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxFiscalYear", _MaxFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MinFiscalYear", _MinFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MaxFiscalYear = _MaxFiscalYear;
				MinFiscalYear = _MinFiscalYear;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
