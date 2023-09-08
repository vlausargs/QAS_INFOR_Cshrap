//PROJECT NAME: Data
//CLASS NAME: IJoblowSetSubJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJoblowSetSubJob
	{
		int? JoblowSetSubJobSp(
			string PList,
			string PJob,
			int? PSuffix,
			int? PLowLevel,
			decimal? PMatlQty,
			string PRefType,
			string PUnits,
			decimal? PScrapFact,
			string PItem);
	}
}

