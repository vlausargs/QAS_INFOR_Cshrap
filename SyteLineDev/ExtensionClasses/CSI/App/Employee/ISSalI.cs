//PROJECT NAME: Employee
//CLASS NAME: ISSalI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ISSalI
	{
		(int? ReturnCode,
		string Infobar) SSalISp(
			string PEmpNum,
			DateTime? PSalDate,
			DateTime? PJobDate,
			decimal? PSalary,
			string PSalaryPeriod,
			string PReasonCode,
			string PPayFreq,
			string Infobar,
			int? PFlageCheckReasonCode = 0);
	}
}

