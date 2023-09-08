//PROJECT NAME: Data
//CLASS NAME: IItemId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemId
	{
		string ItemIdFn(
			string BaseTableName,
			string TableAlias,
			DateTime? RecordDate,
			Guid? RowPointer);
	}
}

