//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedLabelsInsertRecord.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSchedLabelsInsertRecord : ISSSFSSchedLabelsInsertRecord
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedLabelsInsertRecord(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSchedLabelsInsertRecordSp(
			string UserName,
			string SechID,
			string SubType)
		{
			UsernameType _UserName = UserName;
			SerNumType _SechID = SechID;
			BolNumType _SubType = SubType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedLabelsInsertRecordSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SechID", _SechID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubType", _SubType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
