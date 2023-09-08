//PROJECT NAME: Employee
//CLASS NAME: IPrtrxc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPrtrxc
	{
		(int? ReturnCode, string Infobar) PrtrxcSp(string Infobar);
	}
}

