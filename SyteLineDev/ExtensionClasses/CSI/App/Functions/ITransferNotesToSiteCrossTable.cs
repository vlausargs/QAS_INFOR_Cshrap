//PROJECT NAME: Data
//CLASS NAME: ITransferNotesToSiteCrossTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransferNotesToSiteCrossTable
	{
		(int? ReturnCode,
			string Infobar) TransferNotesToSiteCrossTableSp(
			string ToSite,
			string TableName,
			Guid? RowPointer,
			string ToWhereClause,
			string ToJoinClause,
			Guid? ToRowPointer,
			string Infobar,
			string ToTableName = null,
			string RemoteDbName = null);
	}
}

