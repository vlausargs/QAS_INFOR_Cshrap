//PROJECT NAME: Data
//CLASS NAME: IBuildDependencyTablesStatements.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBuildDependencyTablesStatements
	{
		string BuildDependencyTablesStatementsFn(
			string IDO_Name,
			int? From_Source_Table);
	}
}

