//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPOutsidePaperwork.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPOutsidePaperwork
	{
		int? Rpt_RSQC_IPOutsidePaperworkSp(
			string begjob = null,
			int? begsuff = null,
			int? begoper = null);
	}
}

