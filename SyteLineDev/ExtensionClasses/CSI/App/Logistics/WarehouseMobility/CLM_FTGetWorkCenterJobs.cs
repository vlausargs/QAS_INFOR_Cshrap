//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTGetWorkCenterJobs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTGetWorkCenterJobs : ICLM_FTGetWorkCenterJobs
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTGetWorkCenterJobs(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FTGetWorkCenterJobsSp(string WorkCenter,
		string FilterString = null,
		string OrderByString = null,
		string ResouceGroup = null,
		string ResourceId = null,
		int? DateInterval = null)
		{
			PoNumType _WorkCenter = WorkCenter;
			LongListType _FilterString = FilterString;
			LongListType _OrderByString = OrderByString;
			ApsResgroupType _ResouceGroup = ResouceGroup;
			ApsResourceType _ResourceId = ResourceId;
			DateKeyType _DateInterval = DateInterval;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTGetWorkCenterJobsSp";
				
				appDB.AddCommandParameter(cmd, "WorkCenter", _WorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderByString", _OrderByString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResouceGroup", _ResouceGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceId", _ResourceId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateInterval", _DateInterval, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
