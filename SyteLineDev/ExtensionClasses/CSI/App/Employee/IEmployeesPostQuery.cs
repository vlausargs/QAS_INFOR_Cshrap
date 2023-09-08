//PROJECT NAME: Employee
//CLASS NAME: IEmployeesPostQuery.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmployeesPostQuery
	{
		(int? ReturnCode, decimal? Salary,
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
		decimal? MfgDtRate);
	}
}

