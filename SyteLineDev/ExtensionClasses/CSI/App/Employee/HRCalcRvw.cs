//PROJECT NAME: CSIEmployee
//CLASS NAME: HRCalcRvw.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
	public interface IHRCalcRvw
	{
		int HRCalcRvwSp(string PEmpNum,
		                DateTime? PAnniv,
		                DateTime? PRvwDate,
		                ref DateTime? PNewDate);
	}
	
	public class HRCalcRvw : IHRCalcRvw
	{
		readonly IApplicationDB appDB;
		
		public HRCalcRvw(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int HRCalcRvwSp(string PEmpNum,
		                       DateTime? PAnniv,
		                       DateTime? PRvwDate,
		                       ref DateTime? PNewDate)
		{
			EmpNumType _PEmpNum = PEmpNum;
			DateType _PAnniv = PAnniv;
			DateType _PRvwDate = PRvwDate;
			DateType _PNewDate = PNewDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HRCalcRvwSp";
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAnniv", _PAnniv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRvwDate", _PRvwDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDate", _PNewDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PNewDate = _PNewDate;
				
				return Severity;
			}
		}
	}
}
