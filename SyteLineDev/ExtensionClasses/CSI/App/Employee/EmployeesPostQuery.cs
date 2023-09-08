//PROJECT NAME: Employee
//CLASS NAME: EmployeesPostQuery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class EmployeesPostQuery : IEmployeesPostQuery
	{
		readonly IApplicationDB appDB;
		
		
		public EmployeesPostQuery(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Salary,
		decimal? RegRate,
		decimal? OtRate,
		decimal? DtRate,
		decimal? MfgRegRate,
		decimal? MfgOtRate,
		decimal? MfgDtRate) EmployeesPostQuerySP(Guid? EmployeesRowPointer,
		decimal? Salary,
		decimal? RegRate,
		decimal? OtRate,
		decimal? DtRate,
		decimal? MfgRegRate,
		decimal? MfgOtRate,
		decimal? MfgDtRate)
		{
			RowPointerType _EmployeesRowPointer = EmployeesRowPointer;
			PrAmountType _Salary = Salary;
			PayRateType _RegRate = RegRate;
			PayRateType _OtRate = OtRate;
			PayRateType _DtRate = DtRate;
			PayRateType _MfgRegRate = MfgRegRate;
			PayRateType _MfgOtRate = MfgOtRate;
			PayRateType _MfgDtRate = MfgDtRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EmployeesPostQuerySP";
				
				appDB.AddCommandParameter(cmd, "EmployeesRowPointer", _EmployeesRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Salary", _Salary, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RegRate", _RegRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OtRate", _OtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DtRate", _DtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MfgRegRate", _MfgRegRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MfgOtRate", _MfgOtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MfgDtRate", _MfgDtRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Salary = _Salary;
				RegRate = _RegRate;
				OtRate = _OtRate;
				DtRate = _DtRate;
				MfgRegRate = _MfgRegRate;
				MfgOtRate = _MfgOtRate;
				MfgDtRate = _MfgDtRate;
				
				return (Severity, Salary, RegRate, OtRate, DtRate, MfgRegRate, MfgOtRate, MfgDtRate);
			}
		}
	}
}
