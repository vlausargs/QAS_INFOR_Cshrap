//PROJECT NAME: Production
//CLASS NAME: IApsSyncDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncDelete
	{
		int? ApsSyncDeleteSp(
			Guid? Partition);
	}
}

