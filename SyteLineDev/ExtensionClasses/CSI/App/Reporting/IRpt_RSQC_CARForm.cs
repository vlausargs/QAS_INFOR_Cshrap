//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CARForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CARForm
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CARFormSp(
			string begcar = null,
			string endcar = null,
			string begitem = null,
			string enditem = null,
			string begentity = null,
			string endentity = null,
			string beginsp = null,
			string endinsp = null,
			DateTime? begcdate = null,
			DateTime? endcdate = null,
			DateTime? begddate = null,
			DateTime? endddate = null,
			string status = null,
			string reftype = null,
			int? printcost = null,
			int? PrintInternal = null,
			int? PrintExternal = null);
	}
}

