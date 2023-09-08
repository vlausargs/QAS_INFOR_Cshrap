//PROJECT NAME: Data
//CLASS NAME: IUETUnbundle.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUETUnbundle
	{
		(int? ReturnCode,
			string SQLUpdate,
			string SQLUpdateWhere,
			string SQLInsertColumns,
			string SQLInsertValues) UETUnbundleSp(
			string UETListPairs,
			string SQLUpdate = null,
			string SQLUpdateWhere = null,
			string SQLInsertColumns = null,
			string SQLInsertValues = null,
			string TableName = null);
	}
}

