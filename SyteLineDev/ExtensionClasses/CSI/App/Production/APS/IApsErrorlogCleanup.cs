//PROJECT NAME: Production
//CLASS NAME: IApsErrorlogCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsErrorlogCleanup
	{
		int? ApsErrorlogCleanupSp();
	}
}

