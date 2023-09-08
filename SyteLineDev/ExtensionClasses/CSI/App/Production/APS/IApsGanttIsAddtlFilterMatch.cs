//PROJECT NAME: Production
//CLASS NAME: IApsGanttIsAddtlFilterMatch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGanttIsAddtlFilterMatch
	{
		int? ApsGanttIsAddtlFilterMatchFn(
			string Job,
			int? Suffix,
			string FilterCustomer,
			string FilterItem,
			string FilterMaterial);
	}
}

