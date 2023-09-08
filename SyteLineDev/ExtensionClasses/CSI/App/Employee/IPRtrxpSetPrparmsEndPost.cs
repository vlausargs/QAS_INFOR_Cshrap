//PROJECT NAME: Employee
//CLASS NAME: IPRtrxpSetPrparmsEndPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPRtrxpSetPrparmsEndPost
	{
		(int? ReturnCode, string Infobar) PRtrxpSetPrparmsEndPostSp(string Infobar);
	}
}

