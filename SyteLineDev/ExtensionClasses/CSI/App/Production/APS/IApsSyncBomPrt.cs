//PROJECT NAME: Production
//CLASS NAME: IApsSyncBomPrt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncBomPrt
	{
		int? ApsSyncBomPrtSp(
			Guid? Partition);
	}
}

