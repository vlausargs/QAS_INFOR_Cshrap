//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXIETU.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXIETU
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXIETUSp(string EntityStarting = null,
		string EntityEnding = null,
		DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		string IetuClasification = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		string ReportMode = "D",
		int? DisplayHeader = 0,
		string pSite = null);
	}
}

