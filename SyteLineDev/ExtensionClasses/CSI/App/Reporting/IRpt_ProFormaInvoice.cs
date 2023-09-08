//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProFormaInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProFormaInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProFormaInvoiceSP(int? PackStarting = null,
		int? PackEnding = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		string TrnNumParam = null,
		string pSite = null);
	}
}

