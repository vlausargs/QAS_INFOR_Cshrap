//PROJECT NAME: Data
//CLASS NAME: ITruncateDatabase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITruncateDatabase
	{
		int? TruncateDatabaseSp(
			string DbName);
	}
}

