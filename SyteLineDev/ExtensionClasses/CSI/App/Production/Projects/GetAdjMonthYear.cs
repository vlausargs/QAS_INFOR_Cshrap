//PROJECT NAME: CSIProjects
//CLASS NAME: GetAdjMonthYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetAdjMonthYear
	{
		int GetAdjMonthYearSp(ref string pMonth,
		                      ref string pYear);
	}
	
	public class GetAdjMonthYear : IGetAdjMonthYear
	{
		readonly IApplicationDB appDB;
		
		public GetAdjMonthYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAdjMonthYearSp(ref string pMonth,
		                             ref string pYear)
		{
			StringType _pMonth = pMonth;
			StringType _pYear = pYear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAdjMonthYearSp";
				
				appDB.AddCommandParameter(cmd, "pMonth", _pMonth, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pYear", _pYear, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pMonth = _pMonth;
				pYear = _pYear;
				
				return Severity;
			}
		}
	}
}
