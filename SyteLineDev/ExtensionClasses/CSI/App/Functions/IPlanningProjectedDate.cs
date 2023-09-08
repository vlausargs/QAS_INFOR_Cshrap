//PROJECT NAME: Data
//CLASS NAME: IPlanningProjectedDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPlanningProjectedDate
	{
		DateTime? PlanningProjectedDateFn(
			string PProjNum,
			int? PProjTaskNum,
			string Site = null);
	}
}

