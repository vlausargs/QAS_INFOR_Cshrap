//PROJECT NAME: Data
//CLASS NAME: IReallyPopulateLocal_AllTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReallyPopulateLocal_AllTables
	{
		int? ReallyPopulateLocal_AllTablesSp(
			int? Truncate = 0,
			int? IncludeLargeJobTables = 1,
			int? ExcludeLargeJobTables = 0,
			int? IncludeLargeLedgerTables = 1,
			int? ExcludeLargeLedgerTables = 0,
			int? IncludeLargeMatltranTables = 1,
			int? ExcludeLargeMatltranTables = 0,
			int? IncludeOtherTables = 1,
			int? ExcludeOtherTables = 0);
	}
}

