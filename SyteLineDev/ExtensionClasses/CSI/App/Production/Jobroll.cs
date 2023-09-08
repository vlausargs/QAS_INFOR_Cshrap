//PROJECT NAME: Production
//CLASS NAME: Jobroll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Jobroll : IJobroll
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Jobroll(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) JobrollSp(string ExBegFinishJob,
		int? ExBegSuffix,
		string ExEndFinishJob,
		int? ExEndSuffix,
		int? TResetI,
		int? TResetP,
		int? TResetR,
		int? TResetJ,
		int? TUpdateA,
		int? ExOptprResetByProdCost,
		int? ExOptgoListOpts,
		int? BgTaskID = null,
		decimal? UserID = null)
		{
			JobType _ExBegFinishJob = ExBegFinishJob;
			SuffixType _ExBegSuffix = ExBegSuffix;
			JobType _ExEndFinishJob = ExEndFinishJob;
			SuffixType _ExEndSuffix = ExEndSuffix;
			FlagNyType _TResetI = TResetI;
			FlagNyType _TResetP = TResetP;
			FlagNyType _TResetR = TResetR;
			FlagNyType _TResetJ = TResetJ;
			FlagNyType _TUpdateA = TUpdateA;
			FlagNyType _ExOptprResetByProdCost = ExOptprResetByProdCost;
			FlagNyType _ExOptgoListOpts = ExOptgoListOpts;
			GenericNoType _BgTaskID = BgTaskID;
			TokenType _UserID = UserID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobrollSp";
				
				appDB.AddCommandParameter(cmd, "ExBegFinishJob", _ExBegFinishJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegSuffix", _ExBegSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndFinishJob", _ExEndFinishJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndSuffix", _ExEndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TResetI", _TResetI, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TResetP", _TResetP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TResetR", _TResetR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TResetJ", _TResetJ, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUpdateA", _TUpdateA, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprResetByProdCost", _ExOptprResetByProdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoListOpts", _ExOptgoListOpts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
