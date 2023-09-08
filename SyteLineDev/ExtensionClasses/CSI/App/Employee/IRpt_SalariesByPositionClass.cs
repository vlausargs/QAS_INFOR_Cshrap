//PROJECT NAME: Employee
//CLASS NAME: IRpt_SalariesByPositionClass.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_SalariesByPositionClass
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalariesByPositionClassSp(string PEmployeeStarting,
		string PEmployeeEnding,
		string PEmpCategoryStarting,
		string PEmpCategoryEnding,
		string PClassificationStarting,
		string PClassificationEnding,
		DateTime? PHireDateStarting,
		DateTime? PHireDateEnding,
		string PEmploymentStatus,
		string PEmployeeTypes,
		string PSite = null);
	}
}

