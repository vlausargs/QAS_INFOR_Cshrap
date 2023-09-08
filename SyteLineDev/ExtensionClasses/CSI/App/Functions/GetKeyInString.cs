//PROJECT NAME: Data
//CLASS NAME: GetKeyInString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetKeyInString : IGetKeyInString
	{
		readonly IApplicationDB appDB;
		
		public GetKeyInString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PKeyValue) GetKeyInStringSp(
			string PTableNameForKey,
			string PTableName,
			Guid? PRowPointer,
			string PKeyValue)
		{
			StringType _PTableNameForKey = PTableNameForKey;
			StringType _PTableName = PTableName;
			RowPointerType _PRowPointer = PRowPointer;
			LongListType _PKeyValue = PKeyValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetKeyInStringSp";
				
				appDB.AddCommandParameter(cmd, "PTableNameForKey", _PTableNameForKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTableName", _PTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PKeyValue", _PKeyValue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PKeyValue = _PKeyValue;
				
				return (Severity, PKeyValue);
			}
		}
	}
}
