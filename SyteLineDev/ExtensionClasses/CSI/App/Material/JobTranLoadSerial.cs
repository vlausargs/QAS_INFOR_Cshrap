//PROJECT NAME: Material
//CLASS NAME: JobTranLoadSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class JobTranLoadSerial : IJobTranLoadSerial
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public JobTranLoadSerial(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) JobTranLoadSerialSp(decimal? TransNum,
		string Job,
		int? Suffix,
		decimal? QtyMoved,
		string MoveToLocation,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				HugeTransNumType _TransNum = TransNum;
				JobType _Job = Job;
				SuffixType _Suffix = Suffix;
				QtyUnitType _QtyMoved = QtyMoved;
				LocType _MoveToLocation = MoveToLocation;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "JobTranLoadSerialSp";
					
					appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "MoveToLocation", _MoveToLocation, ParameterDirection.Input);
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
