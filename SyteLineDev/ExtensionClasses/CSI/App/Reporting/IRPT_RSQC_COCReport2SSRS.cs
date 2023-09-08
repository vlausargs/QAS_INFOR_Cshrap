//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_COCReport2SSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_COCReport2SSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_COCReport2SSRSSp(int? RcvrNum = null,
		string pSite = null);
	}
}

