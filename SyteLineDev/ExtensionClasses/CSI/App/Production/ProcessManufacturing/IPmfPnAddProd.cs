//PROJECT NAME: Production
//CLASS NAME: IPmfPnAddProd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnAddProd
	{
		(int? ReturnCode,
			string Infobar,
			int? Severity,
			Guid? JobRp) PmfPnAddProdSp(
			string Infobar = null,
			int? Severity = null,
			Guid? PnRp = null,
			Guid? MfSpecOrdRp = null,
			string Item = null,
			string Whse = null,
			decimal? Qty = null,
			string BOMItemOvrd = null,
			int? BOMItemSource = 0,
			Guid? JobRp = null,
			int? AddWipItemIfMissing = 0,
			string WipItem = null,
			decimal? FmDens = null,
			int? OrdType = 0);
	}
}

