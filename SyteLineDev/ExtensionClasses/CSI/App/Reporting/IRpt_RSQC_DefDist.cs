//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_DefDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_DefDist
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_DefDistSp(
			string begitem = null,
			string enditem = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string reftype = null,
			int? displayheader = 0);
	}
}

