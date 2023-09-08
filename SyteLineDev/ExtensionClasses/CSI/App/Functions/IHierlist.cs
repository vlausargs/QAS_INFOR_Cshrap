//PROJECT NAME: Data
//CLASS NAME: IHierlist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHierlist
	{
		(int? ReturnCode,
			int? PNumHierarchies,
			string PHierarchyList,
			string Infobar) HierlistSp(
			string PEntity,
			DateTime? PStartDate,
			DateTime? PEndDate,
			int? PNumHierarchies,
			string PHierarchyList,
			string Infobar);
	}
}

