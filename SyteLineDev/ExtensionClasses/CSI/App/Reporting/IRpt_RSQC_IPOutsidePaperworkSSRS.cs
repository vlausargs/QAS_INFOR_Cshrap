//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPOutsidePaperworkSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPOutsidePaperworkSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPOutsidePaperworkSSRSSp(string begjob = null,
		int? begsuff = null,
		int? begoper = null,
		string psite = null);
	}
}

