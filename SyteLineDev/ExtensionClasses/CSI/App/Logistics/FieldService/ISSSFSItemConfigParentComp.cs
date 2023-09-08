//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSItemConfigParentComp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSItemConfigParentComp
	{
		ICollectionLoadResponse SSSFSItemConfigParentCompFn(
			string ParentItem);
	}
}

