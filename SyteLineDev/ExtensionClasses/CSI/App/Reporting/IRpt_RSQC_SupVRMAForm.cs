//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupVRMAForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupVRMAForm
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVRMAFormSp(
			string begitem = null,
			string enditem = null,
			string begvend = null,
			string endvend = null,
			int? begvrma = null,
			int? endvrma = null,
			string sortby = null,
			int? PrintInternal = null,
			int? PrintExternal = null);
	}
}

