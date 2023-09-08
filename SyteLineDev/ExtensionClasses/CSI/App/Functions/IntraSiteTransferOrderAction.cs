//PROJECT NAME: Data
//CLASS NAME: IntraSiteTransferOrderAction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IntraSiteTransferOrderAction : IIntraSiteTransferOrderAction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public IntraSiteTransferOrderAction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) IntraSiteTransferOrderActionSp(
			string PlannerCodeStarting,
			string PlannerCodeEnding,
			string ItemStarting,
			string ItemEnding,
			string WhseStarting,
			string WhseEnding,
			DateTime? StartDateBeg,
			DateTime? StartDateEnd,
			string Source)
		{
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			DateType _StartDateBeg = StartDateBeg;
			DateType _StartDateEnd = StartDateEnd;
			InfobarType _Source = Source;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IntraSiteTransferOrderActionSp";
				
				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateBeg", _StartDateBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateEnd", _StartDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
