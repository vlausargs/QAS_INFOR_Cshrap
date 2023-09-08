//PROJECT NAME: Data
//CLASS NAME: IPRtrxp1pUpdPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPRtrxp1pUpdPostChecks
	{
		(int? ReturnCode,
			string Infobar) PRtrxp1pUpdPostChecksSp(
			Guid? pPrtrxRowPointer,
			Guid? pEmployeeRowPointer,
			decimal? pEmployeeYtdEmpCon,
			string pListPrtrxDeCode,
			string pListPrtrxDeAmt,
			string Infobar);
	}
}

