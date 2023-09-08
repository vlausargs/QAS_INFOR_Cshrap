//PROJECT NAME: Employee
//CLASS NAME: IPayoutWinMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPayoutWinMessages
	{
		(int? ReturnCode, string Infobar) PayoutWinMessagesSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum,
		string Infobar);
	}
}

