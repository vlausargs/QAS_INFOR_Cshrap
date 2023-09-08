//PROJECT NAME: Production
//CLASS NAME: CLM_ItemBottlenecksMRPAPS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface ICLM_ItemBottlenecksMRPAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemBottlenecksMRPAPSSp(DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? ShowTop = null,
		string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string SourceType = null,
		byte? ListDelayedDemands = null,
		string NotebookTab = null,
		string Period = null,
		int? Interval = null);
	}
	
	public class CLM_ItemBottlenecksMRPAPS : ICLM_ItemBottlenecksMRPAPS
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ItemBottlenecksMRPAPS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemBottlenecksMRPAPSSp(DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? ShowTop = null,
		string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string SourceType = null,
		byte? ListDelayedDemands = null,
		string NotebookTab = null,
		string Period = null,
		int? Interval = null)
		{
			DateType _DateStarting = DateStarting;
			DateType _DateEnding = DateEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			IntType _ShowTop = ShowTop;
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			InfobarType _SourceType = SourceType;
			ListYesNoType _ListDelayedDemands = ListDelayedDemands;
			StringType _NotebookTab = NotebookTab;
			StringType _Period = Period;
			IntType _Interval = Interval;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ItemBottlenecksMRPAPSSp";
				
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
