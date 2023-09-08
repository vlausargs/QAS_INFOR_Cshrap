//PROJECT NAME: Production
//CLASS NAME: CLM_GetJobTranPieceDimensions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CLM_GetJobTranPieceDimensions : ICLM_GetJobTranPieceDimensions
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_GetJobTranPieceDimensions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GetJobTranPieceDimensionsSp(string Job,
		int? Suffix = null,
		decimal? TransNum = null,
		string Whse = null,
		string Location = null,
		string Lot = null,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				JobType _Job = Job;
				SuffixType _Suffix = Suffix;
				HugeTransNumType _TransNum = TransNum;
				WhseType _Whse = Whse;
				LocType _Location = Location;
				LotType _Lot = Lot;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_GetJobTranPieceDimensionsSp";
					
					appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Location", _Location, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
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
