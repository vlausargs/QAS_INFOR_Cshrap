//PROJECT NAME: Production
//CLASS NAME: IMO_SHIFTEXDIMaintIDQuery.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IMO_SHIFTEXDIMaintIDQuery
	{
		(int? ReturnCode, string MaintenanceID,
		DateTime? StartDate,
		DateTime? EndDate,
		string SHIFTID) MO_SHIFTEXDIMaintIDQuerySp(string SHIFTEXID,
		string MaintenanceID,
		DateTime? StartDate,
		DateTime? EndDate,
		string SHIFTID);
	}
}

