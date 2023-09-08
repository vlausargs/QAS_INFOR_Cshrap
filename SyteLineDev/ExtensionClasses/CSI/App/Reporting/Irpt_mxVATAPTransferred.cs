//PROJECT NAME: Reporting
//CLASS NAME: Irpt_mxVATAPTransferred.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface Irpt_mxVATAPTransferred
	{
		(ICollectionLoadResponse Data, int? ReturnCode) rpt_mxVATAPTransferredSp(DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		string pSite = null);
	}
}

