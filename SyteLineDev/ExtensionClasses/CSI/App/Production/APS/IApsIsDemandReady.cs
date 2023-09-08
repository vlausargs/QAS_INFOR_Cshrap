//PROJECT NAME: Production
//CLASS NAME: IApsIsDemandReady.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsIsDemandReady
	{
		int? ApsIsDemandReadyFn(
			string PDemandID);
	}
}

