//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerByItemSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_CustomerByItemSalesAnalysis : IRpt_CustomerByItemSalesAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CustomerByItemSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerByItemSalesAnalysisSp(string COStatus = null,
		string Source = null,
		int? PageBetweenItems = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? PrintPrice = 0,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			StringType _COStatus = COStatus;
			StringType _Source = Source;
			ListYesNoType _PageBetweenItems = PageBetweenItems;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			GenericDateType _OrderDateStarting = OrderDateStarting;
			GenericDateType _OrderDateEnding = OrderDateEnding;
			DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
			DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CustomerByItemSalesAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "COStatus", _COStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
