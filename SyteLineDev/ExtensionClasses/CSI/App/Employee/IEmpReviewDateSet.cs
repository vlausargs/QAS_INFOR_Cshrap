//PROJECT NAME: Employee
//CLASS NAME: IEmpReviewDateSet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmpReviewDateSet
	{
		int? EmpReviewDateSetSp(string EmpNum,
		DateTime? EmpReviewDate);
	}
}

