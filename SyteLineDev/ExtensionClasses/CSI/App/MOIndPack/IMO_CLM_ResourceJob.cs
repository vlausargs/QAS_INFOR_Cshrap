//PROJECT NAME: MOIndPack
//CLASS NAME: IMO_CLM_ResourceJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MOIndPack
{
	public interface IMO_CLM_ResourceJob
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_CLM_ResourceJobSp(string BOMType,
		string CoJob,
		string ProdMix,
		string RESID,
		int? DeleteFlag,
		string FilterString = null);
	}
}

