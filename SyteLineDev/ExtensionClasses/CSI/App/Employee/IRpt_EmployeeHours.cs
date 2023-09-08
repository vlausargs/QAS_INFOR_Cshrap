//PROJECT NAME: Employee
//CLASS NAME: IRpt_EmployeeHours.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_EmployeeHours
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EmployeeHoursSp(string PEmpStarting,
		string PEmpEnding,
		DateTime? PDateStarting,
		DateTime? PDateEnding,
		decimal? PTransStarting,
		decimal? PTransEnding,
		string PEmpType,
		string PPayType,
		int? PPrintCost,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string PSite = null);
	}
}

