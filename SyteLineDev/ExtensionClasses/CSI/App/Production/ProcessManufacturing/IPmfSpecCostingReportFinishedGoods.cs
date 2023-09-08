//PROJECT NAME: Production
//CLASS NAME: IPmfSpecCostingReportFinishedGoods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfSpecCostingReportFinishedGoods
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfSpecCostingReportFinishedGoodsSp(
			string mf_spec,
			string mf_spec_ver,
			string SiteRef);
	}
}

