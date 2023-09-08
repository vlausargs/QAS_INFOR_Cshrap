//PROJECT NAME: Data
//CLASS NAME: IIsCategoryInHierarchy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsCategoryInHierarchy
	{
		int? IsCategoryInHierarchyFn(
			string ItemCategory);
	}
}

