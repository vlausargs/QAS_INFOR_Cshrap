//PROJECT NAME: Production
//CLASS NAME: IApsIsJobFrozen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsIsJobFrozen
	{
		int? ApsIsJobFrozenFn(
			string PJob,
			int? PSuffix);
	}
}

