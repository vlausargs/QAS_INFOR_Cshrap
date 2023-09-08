//PROJECT NAME: Data
//CLASS NAME: UETBundle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UETBundle : IUETBundle
	{
		readonly IApplicationDB appDB;
		
		public UETBundle(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string UETListPairs) UETBundleSp(
			string TableName,
			Guid? RowPointer,
			string UETListPairs)
		{
			TableNameType _TableName = TableName;
			RowPointerType _RowPointer = RowPointer;
			VeryLongListType _UETListPairs = UETListPairs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UETBundleSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UETListPairs = _UETListPairs;
				
				return (Severity, UETListPairs);
			}
		}
	}
}
