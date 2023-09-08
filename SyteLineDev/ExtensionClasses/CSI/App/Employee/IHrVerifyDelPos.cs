//PROJECT NAME: Employee
//CLASS NAME: IHrVerifyDelPos.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IHrVerifyDelPos
	{
		(int? ReturnCode, string Infobar) HrVerifyDelPosSp(string JobId,
		int? JobDetail,
		string Infobar);
	}
}

