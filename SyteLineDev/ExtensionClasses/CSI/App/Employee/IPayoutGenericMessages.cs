//PROJECT NAME: Employee
//CLASS NAME: IPayoutGenericMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPayoutGenericMessages
	{
		(int? ReturnCode, string Infobar) PayoutGenericMessagesSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum,
		string Infobar);
	}
}

