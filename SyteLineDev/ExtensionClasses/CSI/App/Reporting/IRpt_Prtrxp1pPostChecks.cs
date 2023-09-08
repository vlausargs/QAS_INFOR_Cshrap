//PROJECT NAME: Reporting
//CLASS NAME: IRPT_PRtrxp1pPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_PRtrxp1pPostChecks
	{
		(int? ReturnCode,
			string Infobar) RPT_PRtrxp1pPostChecksSp(
			Guid? pPrtrxRowPointer,
			string pSessionIDChar = null,
			string Infobar = null);
	}
}

