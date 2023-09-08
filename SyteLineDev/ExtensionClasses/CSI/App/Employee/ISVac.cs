//PROJECT NAME: Employee
//CLASS NAME: ISVac.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ISVac
	{
		(int? ReturnCode, int? VacationActive,
		decimal? VacationDaysEarned,
		DateTime? VacationLastUpdate,
		string Infobar) SVacSp(string pEmpNum,
		decimal? VacationDaysReimbursed,
		decimal? VacationDaysLytd,
		decimal? VacationDaysUsed,
		int? VacationActive,
		decimal? VacationDaysEarned,
		DateTime? VacationLastUpdate,
		string Infobar);
	}
}

