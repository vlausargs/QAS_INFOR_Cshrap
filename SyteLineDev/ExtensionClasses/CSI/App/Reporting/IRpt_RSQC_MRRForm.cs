//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_MRRForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_MRRForm
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_MRRFormSp(
			string begmrr = null,
			string endmrr = null,
			string begitem = null,
			string enditem = null,
			string beginsp = null,
			string endinsp = null,
			DateTime? begcdate = null,
			DateTime? endcdate = null,
			DateTime? begsdate = null,
			DateTime? endsdate = null,
			string reftype = null,
			int? printcost = null,
			int? showtrans = null,
			int? shownotes = null,
			int? PrintInternal = null,
			int? PrintExternal = null);
	}
}

