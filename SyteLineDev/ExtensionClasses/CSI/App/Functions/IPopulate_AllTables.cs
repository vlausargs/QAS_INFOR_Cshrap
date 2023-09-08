//PROJECT NAME: Data
//CLASS NAME: IPopulate_AllTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPopulate_AllTables
	{
		int? Populate_AllTablesSp();

		int? Populate_AllTablesFn(
			string TableName);
	}
}

