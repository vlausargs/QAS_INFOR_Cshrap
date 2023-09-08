//PROJECT NAME: Production
//CLASS NAME: IApsSetPrioritySp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSetPriority
	{
		int? ApsSetPrioritySp(
			int? POrderType);
	}
}

