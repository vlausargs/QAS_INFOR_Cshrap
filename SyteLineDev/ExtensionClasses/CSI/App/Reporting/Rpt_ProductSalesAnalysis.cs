//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductSalesAnalysis : IRpt_ProductSalesAnalysis
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductSalesAnalysisSp(string StartProdCode = null,
		string EndProdCode = null,
		string StartFamCode = null,
		string EndFamCode = null,
		string StartItem = null,
		string EndItem = null,
		DateTime? AsOfDate = null,
		string UsePriceOrQty = null,
		string SortBy = null,
		int? AsOfDateOffset = null,
		int? PrintPrice = 0,
		int? DisplayHeader = null,
		int? DisplayNonInventoryItem = null,
		int? TaskId = null,
		string pSite = null)
		{
			ProductCodeType _StartProdCode = StartProdCode;
			ProductCodeType _EndProdCode = EndProdCode;
			FamilyCodeType _StartFamCode = StartFamCode;
			FamilyCodeType _EndFamCode = EndFamCode;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			DateType _AsOfDate = AsOfDate;
			Infobar _UsePriceOrQty = UsePriceOrQty;
			Infobar _SortBy = SortBy;
			DateOffsetType _AsOfDateOffset = AsOfDateOffset;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _DisplayNonInventoryItem = DisplayNonInventoryItem;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductSalesAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "StartProdCode", _StartProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProdCode", _EndProdCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartFamCode", _StartFamCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndFamCode", _EndFamCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsePriceOrQty", _UsePriceOrQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDateOffset", _AsOfDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayNonInventoryItem", _DisplayNonInventoryItem, ParameterDirection.Input);
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
