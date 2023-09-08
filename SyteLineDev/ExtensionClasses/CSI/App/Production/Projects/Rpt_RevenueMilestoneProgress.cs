//PROJECT NAME: Production
//CLASS NAME: Rpt_RevenueMilestoneProgress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class Rpt_RevenueMilestoneProgress : IRpt_RevenueMilestoneProgress
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RevenueMilestoneProgress(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RevenueMilestoneProgressSp(string PProjectNumStarting,
		string PProjectNumEnding,
		string PRevMSNumStarting,
		string PRevMSNumEnding,
		string PSite = null)
		{
			ProjNumType _PProjectNumStarting = PProjectNumStarting;
			ProjNumType _PProjectNumEnding = PProjectNumEnding;
			ProjMsNumType _PRevMSNumStarting = PRevMSNumStarting;
			ProjMsNumType _PRevMSNumEnding = PRevMSNumEnding;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RevenueMilestoneProgressSp";
				
				appDB.AddCommandParameter(cmd, "PProjectNumStarting", _PProjectNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjectNumEnding", _PProjectNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRevMSNumStarting", _PRevMSNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRevMSNumEnding", _PRevMSNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
