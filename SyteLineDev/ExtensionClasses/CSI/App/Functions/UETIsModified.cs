//PROJECT NAME: Data
//CLASS NAME: UETIsModified.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UETIsModified : IUETIsModified
	{
		readonly IApplicationDB appDB;
		
		public UETIsModified(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? UETIsModifed) UETIsModifiedSp(
			string TableName,
			string DDTableName,
			Guid? RowPointer,
			int? UETIsModifed)
		{
			TableNameType _TableName = TableName;
			TableNameType _DDTableName = DDTableName;
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _UETIsModifed = UETIsModifed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UETIsModifiedSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DDTableName", _DDTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETIsModifed", _UETIsModifed, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UETIsModifed = _UETIsModifed;
				
				return (Severity, UETIsModifed);
			}
		}
	}
}
