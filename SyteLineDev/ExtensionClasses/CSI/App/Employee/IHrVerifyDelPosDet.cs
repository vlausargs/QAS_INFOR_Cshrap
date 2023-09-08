//PROJECT NAME: Employee
//CLASS NAME: IHrVerifyDelPosDet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IHrVerifyDelPosDet
	{
		(int? ReturnCode, string Infobar) HrVerifyDelPosDetSp(string JobId,
		int? JobDetail,
		string Infobar);
	}
}

