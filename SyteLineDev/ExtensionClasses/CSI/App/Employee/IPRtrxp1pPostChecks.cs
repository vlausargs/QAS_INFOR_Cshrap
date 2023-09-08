//PROJECT NAME: Employee
//CLASS NAME: IPRtrxp1pPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPRtrxp1pPostChecks
	{
		(int? ReturnCode, string Infobar) PRtrxp1pPostChecksSp(Guid? pSessionID,
		Guid? pPrtrxRowPointer,
		string Infobar);
	}
}

