//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostingAnalysisCustomerOrderMargin.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_CostingAnalysisCustomerOrderMargin : IRpt_CostingAnalysisCustomerOrderMargin
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CostingAnalysisCustomerOrderMargin(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CostingAnalysisCustomerOrderMarginSp(string CostingAlt = null,
		int? GroupByCustomer = 0,
		int? GroupByCO = 0,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string EstimateOrderStarting = null,
		string EstimateOrderEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		int? DisplayHeader = 0,
		string OrderType = null,
		string pSite = null)
		{
			CostingAlternativeType _CostingAlt = CostingAlt;
			FlagNyType _GroupByCustomer = GroupByCustomer;
			FlagNyType _GroupByCO = GroupByCO;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CoNumType _EstimateOrderStarting = EstimateOrderStarting;
			CoNumType _EstimateOrderEnding = EstimateOrderEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			FlagNyType _DisplayHeader = DisplayHeader;
			CoTypeType _OrderType = OrderType;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CostingAnalysisCustomerOrderMarginSp";
				
				appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupByCustomer", _GroupByCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupByCO", _GroupByCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateOrderStarting", _EstimateOrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateOrderEnding", _EstimateOrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
