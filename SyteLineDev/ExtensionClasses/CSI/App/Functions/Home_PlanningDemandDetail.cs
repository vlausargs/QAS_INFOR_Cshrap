//PROJECT NAME: Data
//CLASS NAME: Home_PlanningDemandDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Home_PlanningDemandDetail : IHome_PlanningDemandDetail
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Home_PlanningDemandDetail(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Home_PlanningDemandDetailSp(
			int? DetailDisplay,
			int? UseFullyTransactedOrders = 0,
			DateTime? CutoffDate = null,
			string PlanCode = null,
			string Buyer = null,
			string PMTCodes = "PMT")
		{
			Flag _DetailDisplay = DetailDisplay;
			ListYesNoType _UseFullyTransactedOrders = UseFullyTransactedOrders;
			DateTimeType _CutoffDate = CutoffDate;
			UserCodeType _PlanCode = PlanCode;
			UsernameType _Buyer = Buyer;
			StringType _PMTCodes = PMTCodes;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Home_PlanningDemandDetailSp";
				
				appDB.AddCommandParameter(cmd, "DetailDisplay", _DetailDisplay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseFullyTransactedOrders", _UseFullyTransactedOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCode", _PlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCodes", _PMTCodes, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
