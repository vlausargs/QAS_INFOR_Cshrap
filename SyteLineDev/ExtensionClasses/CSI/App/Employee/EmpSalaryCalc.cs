//PROJECT NAME: Employee
//CLASS NAME: EmpSalaryCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class EmpSalaryCalc : IEmpSalaryCalc
	{
		readonly IApplicationDB appDB;
		
		
		public EmpSalaryCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? RegRate,
		decimal? OtRate,
		decimal? DtRate,
		decimal? MfgRegRate,
		decimal? MfgOtRate,
		decimal? MfgdtRate,
		string Infobar) EmpSalaryCalcSp(string PayFreq,
		decimal? Salary,
		decimal? RegRate,
		decimal? OtRate,
		decimal? DtRate,
		decimal? MfgRegRate,
		decimal? MfgOtRate,
		decimal? MfgdtRate,
		string Infobar)
		{
			PrPayFreqType _PayFreq = PayFreq;
			PrAmountType _Salary = Salary;
			PayRateType _RegRate = RegRate;
			PayRateType _OtRate = OtRate;
			PayRateType _DtRate = DtRate;
			PayRateType _MfgRegRate = MfgRegRate;
			PayRateType _MfgOtRate = MfgOtRate;
			PayRateType _MfgdtRate = MfgdtRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EmpSalaryCalcSp";
				
				appDB.AddCommandParameter(cmd, "PayFreq", _PayFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Salary", _Salary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RegRate", _RegRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OtRate", _OtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DtRate", _DtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MfgRegRate", _MfgRegRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MfgOtRate", _MfgOtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MfgdtRate", _MfgdtRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RegRate = _RegRate;
				OtRate = _OtRate;
				DtRate = _DtRate;
				MfgRegRate = _MfgRegRate;
				MfgOtRate = _MfgOtRate;
				MfgdtRate = _MfgdtRate;
				Infobar = _Infobar;
				
				return (Severity, RegRate, OtRate, DtRate, MfgRegRate, MfgOtRate, MfgdtRate, Infobar);
			}
		}
	}
}
