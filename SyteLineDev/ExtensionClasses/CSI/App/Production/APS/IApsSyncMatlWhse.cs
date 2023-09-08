//PROJECT NAME: Production
//CLASS NAME: IApsSyncMatlWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncMatlWhse
	{
		int? ApsSyncMatlWhseSp(
			Guid? Partition);
	}
}

