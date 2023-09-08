//PROJECT NAME: Data
//CLASS NAME: PartitionTableScript.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PartitionTableScript : IPartitionTableScript
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PartitionTableScript(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PartitionTableScriptSp(
			string PDatabaseSchema,
			string PTableName,
			string PPartitionDatabaseSchema)
		{
			ObjectNameType _PDatabaseSchema = PDatabaseSchema;
			ObjectNameType _PTableName = PTableName;
			ObjectNameType _PPartitionDatabaseSchema = PPartitionDatabaseSchema;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PartitionTableScriptSp";
				
				appDB.AddCommandParameter(cmd, "PDatabaseSchema", _PDatabaseSchema, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTableName", _PTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPartitionDatabaseSchema", _PPartitionDatabaseSchema, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
