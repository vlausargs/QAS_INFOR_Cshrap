//PROJECT NAME: Data
//CLASS NAME: ICopyDatabases.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyDatabases
	{
		int? CopyDatabasesSp(
			string DbName,
			string Dest);
	}
}

