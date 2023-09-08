//PROJECT NAME: Employee
//CLASS NAME: ICalcRvw.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICalcRvw
	{
		(int? ReturnCode, DateTime? EmpReviewDate) CalcRvwSp(string EmpNum,
		DateTime? EmpADate,
		DateTime? DatePers,
		DateTime? EmpReviewDate);
	}
}

