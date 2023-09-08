//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsMessages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ApsMessages
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsMessagesSp(int? vError,
		int? vWarning,
		int? vBlocked,
		int? vPlanning,
		int? vScheduling,
		int? vGateway,
		int? vSQL,
		string FilterString = null);
	}
	
	public class CLM_ApsMessages : ICLM_ApsMessages
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsMessages(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsMessagesSp(int? vError,
		int? vWarning,
		int? vBlocked,
		int? vPlanning,
		int? vScheduling,
		int? vGateway,
		int? vSQL,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsIntType _vError = vError;
				ApsIntType _vWarning = vWarning;
				ApsIntType _vBlocked = vBlocked;
				ApsIntType _vPlanning = vPlanning;
				ApsIntType _vScheduling = vScheduling;
				ApsIntType _vGateway = vGateway;
				ApsIntType _vSQL = vSQL;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsMessagesSp";
					
					appDB.AddCommandParameter(cmd, "vError", _vError, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "vWarning", _vWarning, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "vBlocked", _vBlocked, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "vPlanning", _vPlanning, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "vScheduling", _vScheduling, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "vGateway", _vGateway, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "vSQL", _vSQL, ParameterDirection.Input);
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
