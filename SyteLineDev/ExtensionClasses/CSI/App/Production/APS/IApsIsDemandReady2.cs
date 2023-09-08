//PROJECT NAME: Production
//CLASS NAME: IApsIsDemandReady2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsIsDemandReady2
	{
		int? ApsIsDemandReady2Fn(
			string RefType,
			string RefNum);
	}
}

