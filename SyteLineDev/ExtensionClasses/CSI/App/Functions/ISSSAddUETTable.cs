//PROJECT NAME: Data
//CLASS NAME: ISSSAddUETTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSAddUETTable
	{
		int? SSSAddUETTableSp(
			string iClassName,
			string iClassLabel,
			string iClassDesc,
			string iTableName);
	}
}

