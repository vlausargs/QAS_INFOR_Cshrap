//PROJECT NAME: Employee
//CLASS NAME: IPrtrxSetRegularHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPrtrxSetRegularHrs
	{
		(int? ReturnCode, string Infobar) PrtrxSetRegularHrsSp(string EmpNum,
		int? EmpSeq,
		int? PaySalaryStatus,
		string Infobar);
	}
}

