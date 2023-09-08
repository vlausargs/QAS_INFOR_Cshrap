//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_SchedDemandSummaries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_SchedDemandSummaries
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedDemandSummariesSp(DateTime? StartDate,
		DateTime? EndDate,
		short? AltNum = 0,
		string FilterString = null);
	}
	
	public class CLM_SchedDemandSummaries : ICLM_SchedDemandSummaries
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_SchedDemandSummaries(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedDemandSummariesSp(DateTime? StartDate,
		DateTime? EndDate,
		short? AltNum = 0,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DateTimeType _StartDate = StartDate;
				DateTimeType _EndDate = EndDate;
				ApsAltNoType _AltNum = AltNum;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_SchedDemandSummariesSp";
					
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
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
