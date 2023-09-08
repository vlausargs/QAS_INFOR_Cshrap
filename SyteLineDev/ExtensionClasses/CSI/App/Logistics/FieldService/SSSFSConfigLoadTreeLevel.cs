//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigLoadTreeLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigLoadTreeLevel : ISSSFSConfigLoadTreeLevel
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSConfigLoadTreeLevel(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSConfigLoadTreeLevelSp(int? ParentId,
		DateTime? AsOfDate,
		int? IncludeFuture,
		int? IncludeRemoved,
		int? IsParent)
		{
			FSCompIdType _ParentId = ParentId;
			DateType _AsOfDate = AsOfDate;
			ListYesNoType _IncludeFuture = IncludeFuture;
			ListYesNoType _IncludeRemoved = IncludeRemoved;
			ListYesNoType _IsParent = IsParent;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConfigLoadTreeLevelSp";
				
				appDB.AddCommandParameter(cmd, "ParentId", _ParentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeFuture", _IncludeFuture, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeRemoved", _IncludeRemoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsParent", _IsParent, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
