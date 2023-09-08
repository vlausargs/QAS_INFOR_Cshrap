//PROJECT NAME: Data
//CLASS NAME: IGetTopEmpSalaryDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTopEmpSalaryDate
	{
		DateTime? GetTopEmpSalaryDateFn(
			string pEmployeeNumCustNum);
	}
}

