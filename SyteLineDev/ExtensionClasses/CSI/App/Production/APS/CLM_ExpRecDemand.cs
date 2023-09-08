//PROJECT NAME: Production
//CLASS NAME: CLM_ExpRecDemand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CLM_ExpRecDemand : ICLM_ExpRecDemand
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ExpRecDemand(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ExpRecDemandSp(int? Pos,
		string DemandType,
		string DemandNum = null,
		int? DemandLineSuf = 0)
		{
			ShortType _Pos = Pos;
			StringType _DemandType = DemandType;
			StringType _DemandNum = DemandNum;
			ShortType _DemandLineSuf = DemandLineSuf;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ExpRecDemandSp";
				
				appDB.AddCommandParameter(cmd, "Pos", _Pos, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandType", _DemandType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandNum", _DemandNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandLineSuf", _DemandLineSuf, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
