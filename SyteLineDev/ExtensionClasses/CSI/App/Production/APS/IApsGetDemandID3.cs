//PROJECT NAME: Production
//CLASS NAME: IApsGetDemandID3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetDemandID3
	{
		string ApsGetDemandID3Fn(
			string ApsOrderId);
	}
}

