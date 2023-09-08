//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_DemandDetailScheduler.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_DemandDetailScheduler
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DemandDetailSchedulerSp(string ORDERID,
		short? AltNum = 0,
		string Type = "JOB",
		string FilterString = null);
	}
	
	public class CLM_DemandDetailScheduler : ICLM_DemandDetailScheduler
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_DemandDetailScheduler(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_DemandDetailSchedulerSp(string ORDERID,
		short? AltNum = 0,
		string Type = "JOB",
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsOrderType _ORDERID = ORDERID;
				ApsAltNoType _AltNum = AltNum;
				ApsOrderType _Type = Type;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_DemandDetailSchedulerSp";
					
					appDB.AddCommandParameter(cmd, "ORDERID", _ORDERID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
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
