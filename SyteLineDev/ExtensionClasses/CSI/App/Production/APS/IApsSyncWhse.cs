//PROJECT NAME: Production
//CLASS NAME: IApsSyncWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncWhse
	{
		int? ApsSyncWhseSp(
			Guid? Partition);
	}
}

