//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PSTInvoiced.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PSTInvoiced
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PSTInvoicedSp(DateTime? SPerDate = null,
		DateTime? EPerDate = null,
		int? SPerDateOffSET = null,
		int? EPerDateOffSET = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

