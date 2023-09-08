//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSchedResGrpUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSchedResGrpUtil : ICLM_ApsGetSchedResGrpUtil
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ApsGetSchedResGrpUtil(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSchedResGrpUtilSp(int? AltNum,
		DateTime? StartDate,
		int? IntervalCount,
		int? IntervalType,
		decimal? Threshold,
		string RGID,
		int? ExcludeInfinite,
		int? GroupAllocOnly,
		string WildCardChar,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ApsAltNoType _AltNum = AltNum;
				DateType _StartDate = StartDate;
				ShortType _IntervalCount = IntervalCount;
				ShortType _IntervalType = IntervalType;
				DecimalType _Threshold = Threshold;
				ApsResgroupType _RGID = RGID;
				ListYesNoType _ExcludeInfinite = ExcludeInfinite;
				ListYesNoType _GroupAllocOnly = GroupAllocOnly;
				StringType _WildCardChar = WildCardChar;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ApsGetSchedResGrpUtilSp";
					
					appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IntervalCount", _IntervalCount, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IntervalType", _IntervalType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Threshold", _Threshold, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "RGID", _RGID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExcludeInfinite", _ExcludeInfinite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "GroupAllocOnly", _GroupAllocOnly, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "WildCardChar", _WildCardChar, ParameterDirection.Input);
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
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
