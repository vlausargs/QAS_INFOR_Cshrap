//PROJECT NAME: Data
//CLASS NAME: IUETIsModified.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUETIsModified
	{
		(int? ReturnCode,
			int? UETIsModifed) UETIsModifiedSp(
			string TableName,
			string DDTableName,
			Guid? RowPointer,
			int? UETIsModifed);
	}
}

