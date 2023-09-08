//PROJECT NAME: Employee
//CLASS NAME: IEmpSalaryCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmpSalaryCalc
	{
		(int? ReturnCode, decimal? RegRate,
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
		string Infobar);
	}
}

