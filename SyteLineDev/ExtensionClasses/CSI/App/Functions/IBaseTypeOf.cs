//PROJECT NAME: Data
//CLASS NAME: IBaseTypeOf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBaseTypeOf
	{
		string BaseTypeOfFn(
			string TableName,
			string ColumnName);
	}
}

