//PROJECT NAME: Production
//CLASS NAME: IApsSchedulerStart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSchedulerStart
	{
		int? ApsSchedulerStartSp(
			int? AltNo,
			int? ProcessID);
	}
}

