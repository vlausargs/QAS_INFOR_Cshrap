//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetDelayDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsGetDelayDetails : ICLM_ApsGetDelayDetails
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetDelayDetails(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetDelayDetailsSp(int? AltNo,
		int? WaitMatltag,
		string WaitJsid,
		string WaitType,
		string WaitID,
		DateTime? EarliestStart,
		DateTime? ActualEnd,
		string SubFilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsAltNoType _AltNo = AltNo;
				ApsItemTagType _WaitMatltag = WaitMatltag;
				ApsJobstepType _WaitJsid = WaitJsid;
				ApsCodeType _WaitType = WaitType;
				ApsMaterialType _WaitID = WaitID;
				DateType _EarliestStart = EarliestStart;
				DateType _ActualEnd = ActualEnd;
				LongListType _SubFilterString = SubFilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsGetDelayDetailsSp";
					
					appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WaitMatltag", _WaitMatltag, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WaitJsid", _WaitJsid, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WaitType", _WaitType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WaitID", _WaitID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EarliestStart", _EarliestStart, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ActualEnd", _ActualEnd, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SubFilterString", _SubFilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
