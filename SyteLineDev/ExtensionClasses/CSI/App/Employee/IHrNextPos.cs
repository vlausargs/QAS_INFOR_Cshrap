//PROJECT NAME: Employee
//CLASS NAME: IHrNextPos.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IHrNextPos
	{
		(int? ReturnCode, string PosDefault,
		string Infobar) HrNextPosSp(string PosDefault,
		string Infobar);
	}
}

