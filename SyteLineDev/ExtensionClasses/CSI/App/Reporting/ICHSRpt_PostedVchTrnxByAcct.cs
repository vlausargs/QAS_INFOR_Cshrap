//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_PostedVchTrnxByAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_PostedVchTrnxByAcct
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PostedVchTrnxByAcctSp(string SessionId,
		string pSite = null);
	}
}

