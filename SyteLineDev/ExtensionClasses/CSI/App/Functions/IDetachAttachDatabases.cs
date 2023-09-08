//PROJECT NAME: Data
//CLASS NAME: IDetachAttachDatabases.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDetachAttachDatabases
	{
		int? DetachAttachDatabasesSp(
			string DbName,
			int? Drop = 1,
			int? Attach = 1);
	}
}

