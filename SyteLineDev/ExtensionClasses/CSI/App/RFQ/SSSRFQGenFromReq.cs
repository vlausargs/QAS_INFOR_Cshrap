//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQGenFromReq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public interface ISSSRFQGenFromReq
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRFQGenFromReqSp(byte? Commit,
		string ReqNum,
		short? StartReqLine,
		short? EndReqLine,
		string GenMethod,
		string RollupMethod,
		byte? AllowDuplicates,
		string AppendRfqNum,
		string PSessiondId);
	}
	
	public class SSSRFQGenFromReq : ISSSRFQGenFromReq
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRFQGenFromReq(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRFQGenFromReqSp(byte? Commit,
		string ReqNum,
		short? StartReqLine,
		short? EndReqLine,
		string GenMethod,
		string RollupMethod,
		byte? AllowDuplicates,
		string AppendRfqNum,
		string PSessiondId)
		{
			ListYesNoType _Commit = Commit;
			ReqNumType _ReqNum = ReqNum;
			ReqLineType _StartReqLine = StartReqLine;
			ReqLineType _EndReqLine = EndReqLine;
			StringType _GenMethod = GenMethod;
			StringType _RollupMethod = RollupMethod;
			ListYesNoType _AllowDuplicates = AllowDuplicates;
			RFQNumType _AppendRfqNum = AppendRfqNum;
			StringType _PSessiondId = PSessiondId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQGenFromReqSp";
				
				appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartReqLine", _StartReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqLine", _EndReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenMethod", _GenMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RollupMethod", _RollupMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowDuplicates", _AllowDuplicates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppendRfqNum", _AppendRfqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessiondId", _PSessiondId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
