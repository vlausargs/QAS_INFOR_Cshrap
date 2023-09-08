//PROJECT NAME: Production
//CLASS NAME: IApsGetPlannerDatabaseSize.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetPlannerDatabaseSize
	{
		(int? ReturnCode,
			int? PDBSize) ApsGetPlannerDatabaseSizeSp(
			int? AltNo = 0,
			int? PDBSize = null);
	}
}

