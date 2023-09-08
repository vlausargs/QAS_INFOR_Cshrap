//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CustRMAAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CustRMAAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustRMAAnalysisSp(
			string begitem = null,
			string enditem = null,
			string begcust = null,
			string endcust = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string sortby = null,
			int? displayheader = null);
	}
}

