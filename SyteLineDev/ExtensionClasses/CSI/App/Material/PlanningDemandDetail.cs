//PROJECT NAME: Material
//CLASS NAME: PlanningDemandDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Material
{
	public class PlanningDemandDetail : IPlanningDemandDetail
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public PlanningDemandDetail(IApplicationDB appDB,
			IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
			IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		public ICollectionLoadResponse PlanningDemandDetailFn(int? DetailDisplay, int? UseFullyTransactedOrders = 0, DateTime? CutoffDate = null, string PlanCode = null, string Buyer = null, string PMTCodes = "PMT")
        {
            Flag _DetailDisplay = DetailDisplay;
			ListYesNoType _UseFullyTransactedOrders = UseFullyTransactedOrders;
			DateTimeType _CutoffDate = CutoffDate;
			UserCodeType _PlanCode = PlanCode;
			UsernameType _Buyer = Buyer;
			StringType _PMTCodes = PMTCodes;

			using (IDbCommand cmd = appDB.CreateCommand())
            {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select * from dbo.[PlanningDemandDetail](@DetailDisplay, @UseFullyTransactedOrders, @CutoffDate, @PlanCode, @Buyer, @PMTCodes)";

				appDB.AddCommandParameter(cmd, "DetailDisplay", _DetailDisplay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseFullyTransactedOrders", _UseFullyTransactedOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCode", _PlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCodes", _PMTCodes, ParameterDirection.Input);

				DataTable dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_PlanningDemandDetail";
				this.dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}


		}

        public (ICollectionLoadResponse Data, int? ReturnCode) PlanningDemandDetailSp(DateTime? CutOffDate,
		string PlanCode,
		string Buyer,
		string PMTCodes,
		string FilterString = null)
		{
			DateType _CutOffDate = CutOffDate;
			UserCodeType _PlanCode = PlanCode;
			UsernameType _Buyer = Buyer;
			StringType _PMTCodes = PMTCodes;
			LongListType _FilterString = FilterString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PlanningDemandDetailSp";
				
				appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCode", _PlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCodes", _PMTCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
