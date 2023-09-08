//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteBOMComponents.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IDeleteBOMComponents
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DeleteBOMComponentsSp(string PProcess,
		string PItem,
		string PJType,
		DateTime? PEffDate,
		DateTime? PObsDate,
		string FilterString = null);
	}
	
	public class DeleteBOMComponents : IDeleteBOMComponents
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public DeleteBOMComponents(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) DeleteBOMComponentsSp(string PProcess,
		string PItem,
		string PJType,
		DateTime? PEffDate,
		DateTime? PObsDate,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _PProcess = PProcess;
				ItemType _PItem = PItem;
				LongListType _PJType = PJType;
				CurrentDateType _PEffDate = PEffDate;
				CurrentDateType _PObsDate = PObsDate;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "DeleteBOMComponentsSp";
					
					appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PJType", _PJType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEffDate", _PEffDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PObsDate", _PObsDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
