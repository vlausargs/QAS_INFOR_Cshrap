//PROJECT NAME: Employee
//CLASS NAME: IPrtrxVoidOneCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPrtrxVoidOneCheck
	{
		(int? ReturnCode, string Infobar) PrtrxVoidOneCheckSp(Guid? pSessionID,
		Guid? pPrtrxRowPointer,
		string Infobar);
	}
}

