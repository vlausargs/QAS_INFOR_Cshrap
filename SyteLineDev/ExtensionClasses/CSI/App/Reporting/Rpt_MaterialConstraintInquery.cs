//PROJECT NAME: Reporting
//CLASS NAME: RPT_MaterialConstraintInquery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_MaterialConstraintInquery : IRPT_MaterialConstraintInquery
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_MaterialConstraintInquery(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_MaterialConstraintInquerySP(
			string pSite,
			DateTime? DateStarting,
			DateTime? DateEnding,
			string ItemStarting,
			string ItemEnding,
			int? ShowTop,
			string PlannerCodeStarting,
			string PlannerCodeEnding,
			string SourceType,
			int? ListDelayedDemands,
			string NotebookTab,
			string Period,
			int? Interval)
		{
			StringType _pSite = pSite;
			DateTimeType _DateStarting = DateStarting;
			DateTimeType _DateEnding = DateEnding;
			StringType _ItemStarting = ItemStarting;
			StringType _ItemEnding = ItemEnding;
			IntType _ShowTop = ShowTop;
			StringType _PlannerCodeStarting = PlannerCodeStarting;
			StringType _PlannerCodeEnding = PlannerCodeEnding;
			StringType _SourceType = SourceType;
			IntType _ListDelayedDemands = ListDelayedDemands;
			StringType _NotebookTab = NotebookTab;
			StringType _Period = Period;
			IntType _Interval = Interval;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_MaterialConstraintInquerySP";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStarting", _DateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEnding", _DateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowTop", _ShowTop, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceType", _SourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListDelayedDemands", _ListDelayedDemands, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotebookTab", _NotebookTab, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Interval", _Interval, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
