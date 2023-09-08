//PROJECT NAME: Employee
//CLASS NAME: IHrNextPosDet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IHrNextPosDet
	{
		(int? ReturnCode, int? JobDetail,
		string Infobar) HrNextPosDetSp(string Position,
		int? JobDetail,
		string Infobar);
	}
}

