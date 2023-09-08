//PROJECT NAME: Data
//CLASS NAME: IForeignKeyExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IForeignKeyExists
	{
		int? ForeignKeyExistsFn(
			string TableName);
	}
}

