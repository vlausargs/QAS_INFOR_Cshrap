//PROJECT NAME: Data
//CLASS NAME: Pop_AllTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Pop_AllTables : IPop_AllTables
	{
		readonly IApplicationDB appDB;
		
		public Pop_AllTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string AllCode1,
			string AllCode2,
			string AllCode3,
			string AllCode4) Pop_AllTablesSp(
			string TableName,
			string AllCode1,
			string AllCode2,
			string AllCode3,
			string AllCode4)
		{
			StringType _TableName = TableName;
			StringType _AllCode1 = AllCode1;
			StringType _AllCode2 = AllCode2;
			StringType _AllCode3 = AllCode3;
			StringType _AllCode4 = AllCode4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pop_AllTablesSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllCode1", _AllCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllCode2", _AllCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllCode3", _AllCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllCode4", _AllCode4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AllCode1 = _AllCode1;
				AllCode2 = _AllCode2;
				AllCode3 = _AllCode3;
				AllCode4 = _AllCode4;
				
				return (Severity, AllCode1, AllCode2, AllCode3, AllCode4);
			}
		}
	}
}
