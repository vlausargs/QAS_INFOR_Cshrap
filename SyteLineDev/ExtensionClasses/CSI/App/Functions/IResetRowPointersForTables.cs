//PROJECT NAME: Data
//CLASS NAME: IResetRowPointersForTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IResetRowPointersForTables
	{
		(int? ReturnCode,
			string Infobar) ResetRowPointersForTablesSp(
			string SiteName,
			string TableName,
			string Infobar);
	}
}

