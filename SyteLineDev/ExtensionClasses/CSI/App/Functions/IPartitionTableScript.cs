//PROJECT NAME: Data
//CLASS NAME: IPartitionTableScript.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPartitionTableScript
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PartitionTableScriptSp(
			string PDatabaseSchema,
			string PTableName,
			string PPartitionDatabaseSchema);
	}
}

