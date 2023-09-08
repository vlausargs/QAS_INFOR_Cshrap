//PROJECT NAME: Production
//CLASS NAME: IApsCurrentBomId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCurrentBomId
	{
		int? ApsCurrentBomIdFn();
	}
}

