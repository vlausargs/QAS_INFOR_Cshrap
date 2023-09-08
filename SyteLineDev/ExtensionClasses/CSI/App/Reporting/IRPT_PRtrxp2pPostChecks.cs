//PROJECT NAME: Reporting
//CLASS NAME: IRPT_PRtrxp2pPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_PRtrxp2pPostChecks
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_PRtrxp2pPostChecksSp(string pEmpType,
		string pSite = null,
		string BGUser = null);
	}
}

