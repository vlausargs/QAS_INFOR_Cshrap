//PROJECT NAME: Data
//CLASS NAME: IPartitionAndCopyTableWrapper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPartitionAndCopyTableWrapper
	{
		(int? ReturnCode,
			string Infobar) PartitionAndCopyTableWrapperSp(
			string PTableName,
			string Infobar);
	}
}

