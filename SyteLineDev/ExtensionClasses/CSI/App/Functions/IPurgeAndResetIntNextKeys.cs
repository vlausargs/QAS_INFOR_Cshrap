//PROJECT NAME: Data
//CLASS NAME: IPurgeAndResetIntNextKeys.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPurgeAndResetIntNextKeys
	{
		int? PurgeAndResetIntNextKeysSp(
			string TableName,
			string ColumnName,
			string SubKeyName,
			string SubKeyValue);
	}
}

