//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SalesValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SalesValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalesValueSp(string ItemStarting = null,
		string ItemEnding = null,
		int? ExOptprReportYear = null,
		int? PrintPrice = 0,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

