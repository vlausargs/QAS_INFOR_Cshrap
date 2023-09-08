//PROJECT NAME: Production
//CLASS NAME: IRSQC_CLM_MRR_Cost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CLM_MRR_Cost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_CLM_MRR_CostSp();
	}
}

