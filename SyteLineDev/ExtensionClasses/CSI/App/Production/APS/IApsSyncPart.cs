//PROJECT NAME: Production
//CLASS NAME: IApsSyncPart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncPart
	{
		int? ApsSyncPartSp(
			Guid? Partition);
	}
}

