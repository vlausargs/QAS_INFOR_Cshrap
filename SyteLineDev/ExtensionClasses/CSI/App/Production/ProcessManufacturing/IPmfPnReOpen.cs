//PROJECT NAME: Production
//CLASS NAME: IPmfPnReOpen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnReOpen
	{
		(int? ReturnCode,
		string InfoBar) PmfPnReOpenSp(
			string InfoBar = null,
			Guid? PnRp = null);
	}
}

