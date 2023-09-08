//PROJECT NAME: Data
//CLASS NAME: ReallyPopulateLocal_AllTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReallyPopulateLocal_AllTables : IReallyPopulateLocal_AllTables
	{
		readonly IApplicationDB appDB;
		
		public ReallyPopulateLocal_AllTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ReallyPopulateLocal_AllTablesSp(
			int? Truncate = 0,
			int? IncludeLargeJobTables = 1,
			int? ExcludeLargeJobTables = 0,
			int? IncludeLargeLedgerTables = 1,
			int? ExcludeLargeLedgerTables = 0,
			int? IncludeLargeMatltranTables = 1,
			int? ExcludeLargeMatltranTables = 0,
			int? IncludeOtherTables = 1,
			int? ExcludeOtherTables = 0)
		{
			IntType _Truncate = Truncate;
			IntType _IncludeLargeJobTables = IncludeLargeJobTables;
			IntType _ExcludeLargeJobTables = ExcludeLargeJobTables;
			IntType _IncludeLargeLedgerTables = IncludeLargeLedgerTables;
			IntType _ExcludeLargeLedgerTables = ExcludeLargeLedgerTables;
			IntType _IncludeLargeMatltranTables = IncludeLargeMatltranTables;
			IntType _ExcludeLargeMatltranTables = ExcludeLargeMatltranTables;
			IntType _IncludeOtherTables = IncludeOtherTables;
			IntType _ExcludeOtherTables = ExcludeOtherTables;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReallyPopulateLocal_AllTablesSp";
				
				appDB.AddCommandParameter(cmd, "Truncate", _Truncate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeLargeJobTables", _IncludeLargeJobTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeLargeJobTables", _ExcludeLargeJobTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeLargeLedgerTables", _IncludeLargeLedgerTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeLargeLedgerTables", _ExcludeLargeLedgerTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeLargeMatltranTables", _IncludeLargeMatltranTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeLargeMatltranTables", _ExcludeLargeMatltranTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeOtherTables", _IncludeOtherTables, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeOtherTables", _ExcludeOtherTables, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
