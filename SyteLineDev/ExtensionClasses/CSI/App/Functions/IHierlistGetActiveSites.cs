//PROJECT NAME: Data
//CLASS NAME: IHierlistGetActiveSites.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHierlistGetActiveSites
	{
		(int? ReturnCode,
			int? PNumHierarchies,
			string PHierarchyList,
			string Infobar) HierlistGetActiveSitesSp(
			string PEntity,
			string PHierarchy,
			DateTime? PStartDate,
			DateTime? PEndDate,
			int? PNumHierarchies,
			string PHierarchyList,
			string Infobar);
	}
}

