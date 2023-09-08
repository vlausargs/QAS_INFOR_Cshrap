//PROJECT NAME: Production
//CLASS NAME: IPmfPnAddFm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnAddFm
	{
		(int? ReturnCode,
			string InfoBar,
			Guid? PnFmRp,
			Guid? JobRp) PmfPnAddFmSp(
			string InfoBar = null,
			string Pn = null,
			Guid? PnRp = null,
			Guid? FmRp = null,
			string Whse = null,
			string FmRouteItemJobType = null,
			string FmRouteItem = null,
			string WipItem = null,
			Guid? PnFmRp = null,
			Guid? JobRp = null);
	}
}

