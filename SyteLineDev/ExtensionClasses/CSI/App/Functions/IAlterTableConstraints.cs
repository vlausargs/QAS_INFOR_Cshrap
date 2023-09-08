//PROJECT NAME: Data
//CLASS NAME: IAlterTableConstraints.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAlterTableConstraints
	{
		int? AlterTableConstraintsSp(
			string Action,
			string TableName = null);
	}
}

