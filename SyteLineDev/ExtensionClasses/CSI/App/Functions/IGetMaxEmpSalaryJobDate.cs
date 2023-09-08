//PROJECT NAME: Data
//CLASS NAME: IGetMaxEmpSalaryJobDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetMaxEmpSalaryJobDate
	{
		DateTime? GetMaxEmpSalaryJobDateFn(
			string pEmployeeNumCustNum);
	}
}

