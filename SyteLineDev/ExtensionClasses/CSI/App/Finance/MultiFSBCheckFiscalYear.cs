//PROJECT NAME: Finance
//CLASS NAME: MultiFSBCheckFiscalYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBCheckFiscalYear
	{
		(int? ReturnCode, short? MaxFiscalYear, short? MinFiscalYear, string Infobar) MultiFSBCheckFiscalYearSp(string PeriodName,
		                                                                                                        short? NewFiscalYear,
		                                                                                                        short? MaxFiscalYear,
		                                                                                                        short? MinFiscalYear,
		                                                                                                        string Infobar);
	}
	
	public class MultiFSBCheckFiscalYear : IMultiFSBCheckFiscalYear
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBCheckFiscalYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? MaxFiscalYear, short? MinFiscalYear, string Infobar) MultiFSBCheckFiscalYearSp(string PeriodName,
		                                                                                                               short? NewFiscalYear,
		                                                                                                               short? MaxFiscalYear,
		                                                                                                               short? MinFiscalYear,
		                                                                                                               string Infobar)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			FiscalYearType _NewFiscalYear = NewFiscalYear;
			FiscalYearType _MaxFiscalYear = MaxFiscalYear;
			FiscalYearType _MinFiscalYear = MinFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBCheckFiscalYearSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewFiscalYear", _NewFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxFiscalYear", _MaxFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MinFiscalYear", _MinFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MaxFiscalYear = _MaxFiscalYear;
				MinFiscalYear = _MinFiscalYear;
				Infobar = _Infobar;
				
				return (Severity, MaxFiscalYear, MinFiscalYear, Infobar);
			}
		}
	}
}
