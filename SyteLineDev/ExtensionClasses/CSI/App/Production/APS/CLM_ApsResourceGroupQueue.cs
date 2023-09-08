//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsResourceGroupQueue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ApsResourceGroupQueue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsResourceGroupQueueSp(string PGroup,
		DateTime? PStartDate,
		string FilterString = null);
	}
	
	public class CLM_ApsResourceGroupQueue : ICLM_ApsResourceGroupQueue
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsResourceGroupQueue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsResourceGroupQueueSp(string PGroup,
		DateTime? PStartDate,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsResgroupType _PGroup = PGroup;
				DateType _PStartDate = PStartDate;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsResourceGroupQueueSp";
					
					appDB.AddCommandParameter(cmd, "PGroup", _PGroup, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
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
