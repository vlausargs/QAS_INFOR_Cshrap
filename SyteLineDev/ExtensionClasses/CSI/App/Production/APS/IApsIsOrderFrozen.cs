//PROJECT NAME: Production
//CLASS NAME: IApsIsOrderFrozen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsIsOrderFrozen
	{
		int? ApsIsOrderFrozenFn(
			string POrder);
	}
}

