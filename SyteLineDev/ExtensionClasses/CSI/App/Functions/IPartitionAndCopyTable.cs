//PROJECT NAME: Data
//CLASS NAME: IPartitionAndCopyTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPartitionAndCopyTable
	{
		(int? ReturnCode,
			string FullTextIndexString,
			string Infobar) PartitionAndCopyTableSp(
			string PDatabaseSchema,
			string PTableName,
			string PSiteColumn,
			string FullTextIndexString,
			string Infobar);
	}
}

