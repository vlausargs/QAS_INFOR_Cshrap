//PROJECT NAME: Production
//CLASS NAME: IApsDisableGateway.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsDisableGateway
	{
		int? ApsDisableGatewaySp(
			string AltNo);
	}
}

