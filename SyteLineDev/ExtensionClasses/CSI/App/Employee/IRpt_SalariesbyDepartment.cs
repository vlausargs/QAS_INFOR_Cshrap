//PROJECT NAME: Employee
//CLASS NAME: IRpt_SalariesbyDepartment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_SalariesbyDepartment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalariesbyDepartmentSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PDepartmentStarting,
		string PDepartmentEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEEOClassStarting,
		string PEEOClassEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		string PSite = null);
	}
}

