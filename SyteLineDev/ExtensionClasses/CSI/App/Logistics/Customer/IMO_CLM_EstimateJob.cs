//PROJECT NAME: Logistics
//CLASS NAME: IMO_CLM_EstimateJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IMO_CLM_EstimateJob
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_CLM_EstimateJobSp(string CoNum,
		string RESID,
		string BOMType,
		string CoProductMix,
		int? ProductCycle);
	}
}

