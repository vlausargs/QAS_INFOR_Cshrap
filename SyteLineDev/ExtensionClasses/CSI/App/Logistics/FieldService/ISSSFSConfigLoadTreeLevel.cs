//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigLoadTreeLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigLoadTreeLevel
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSConfigLoadTreeLevelSp(int? ParentId,
		DateTime? AsOfDate,
		int? IncludeFuture,
		int? IncludeRemoved,
		int? IsParent);
	}
}

