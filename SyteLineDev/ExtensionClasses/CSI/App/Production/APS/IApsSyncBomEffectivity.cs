//PROJECT NAME: Production
//CLASS NAME: IApsSyncBomEffectivity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncBomEffectivity
	{
		int? ApsSyncBomEffectivitySp(
			Guid? Partition);
	}
}

