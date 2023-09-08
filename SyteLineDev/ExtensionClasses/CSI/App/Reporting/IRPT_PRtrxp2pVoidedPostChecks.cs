//PROJECT NAME: Reporting
//CLASS NAME: IRPT_PRtrxp2pVoidedPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_PRtrxp2pVoidedPostChecks
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_PRtrxp2pVoidedPostChecksSp(string pEmpType,
		string pSite = null,
		string BGUser = null);
	}
}

