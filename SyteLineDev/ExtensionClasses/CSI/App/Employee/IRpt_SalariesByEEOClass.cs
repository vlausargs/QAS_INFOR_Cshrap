//PROJECT NAME: Employee
//CLASS NAME: IRpt_SalariesByEEOClass.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_SalariesByEEOClass
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalariesByEEOClassSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEEOClassStarting,
		string PEEOClassEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		string PSite = null);
	}
}

