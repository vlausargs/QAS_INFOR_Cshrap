//PROJECT NAME: Data
//CLASS NAME: IProdMixIrtSyncNeeded.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProdMixIrtSyncNeeded
	{
		int? ProdMixIrtSyncNeededFn(
			string ProdMix,
			DateTime? Today);
	}
}

