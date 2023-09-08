//PROJECT NAME: Production
//CLASS NAME: ICLM_GetContentionDetailsByType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_GetContentionDetailsByType
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetContentionDetailsByTypeSp(string Group,
		DateTime? StartDate,
		DateTime? EndDate,
		int? AltNo,
		string DisplayType,
		int? RecordCap,
		int? Interval,
		string Period,
		string GroupType,
		int? ExcludeInfinite,
		string WildCardChar);
	}
}

