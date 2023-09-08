//PROJECT NAME: Material
//CLASS NAME: MRPOrderAction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MRPOrderAction : IMRPOrderAction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MRPOrderAction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MRPOrderActionSp(
			string PlannerCodeStarting,
			string PlannerCodeEnding,
			string ItemStarting,
			string ItemEnding,
			DateTime? StartDate,
			DateTime? EndDate,
			string Source,
			int? TempPlannerCode,
			int? IncludeNull)
		{
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			InfobarType _Source = Source;
			ByteType _TempPlannerCode = TempPlannerCode;
			ByteType _IncludeNull = IncludeNull;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MRPOrderActionSp";
				
				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TempPlannerCode", _TempPlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeNull", _IncludeNull, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
