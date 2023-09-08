//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_PPMSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_PPMSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_PPMSubSp(
			string sortby,
			string begitem,
			string enditem,
			string begvend,
			string endvend,
			DateTime? firstbegdate,
			DateTime? lastenddate,
			DateTime? rptbegdate,
			DateTime? rptenddate);
	}
}

