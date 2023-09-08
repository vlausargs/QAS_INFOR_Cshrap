//PROJECT NAME: Production
//CLASS NAME: IPmfPnUpdProd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnUpdProd
	{
		(int? ReturnCode,
			string Infobar,
			Guid? JobRp) PmfPnUpdProdSp(
			string Infobar = null,
			Guid? JobRp = null,
			decimal? NewQty = null,
			int? DoRoll = 0);
	}
}

