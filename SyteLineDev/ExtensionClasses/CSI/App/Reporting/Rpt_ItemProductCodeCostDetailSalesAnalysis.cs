//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemProductCodeCostDetailSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemProductCodeCostDetailSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemProductCodeCostDetailSalesAnalysisSp(DateTime? AsOfDate = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		short? AsOfDateOffset = null,
		byte? PrintPrice = (byte)0,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ItemProductCodeCostDetailSalesAnalysis : IRpt_ItemProductCodeCostDetailSalesAnalysis
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemProductCodeCostDetailSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemProductCodeCostDetailSalesAnalysisSp(DateTime? AsOfDate = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		short? AsOfDateOffset = null,
		byte? PrintPrice = (byte)0,
		byte? PrintCost = (byte)0,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			DateType _AsOfDate = AsOfDate;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			DateOffsetType _AsOfDateOffset = AsOfDateOffset;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemProductCodeCostDetailSalesAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDateOffset", _AsOfDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
