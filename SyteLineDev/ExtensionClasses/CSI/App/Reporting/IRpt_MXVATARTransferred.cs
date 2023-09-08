//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXVATARTransferred.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXVATARTransferred
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXVATARTransferredSp(DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		string pSite = null);
	}
}

