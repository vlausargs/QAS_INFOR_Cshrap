//PROJECT NAME: Finance
//CLASS NAME: GenerateFsbPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GenerateFsbPeriods : IGenerateFsbPeriods
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateFsbPeriods(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GenerateFsbPeriodsSp(int? FiscalYear,
		string PeriodName,
		int? StepMonths)
		{
			FiscalYearType _FiscalYear = FiscalYear;
			FSBPeriodNameType _PeriodName = PeriodName;
			IntType _StepMonths = StepMonths;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateFsbPeriodsSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StepMonths", _StepMonths, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
