//PROJECT NAME: Employee
//CLASS NAME: IRpt_SalariesByGender.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_SalariesByGender
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalariesByGenderSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		string PSite = null);
	}
}

