//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemCosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCostingSp(string pMatlType = null,
		string pPMTCode = null,
		string pStocked = null,
		string pAbcCode = null,
		byte? pPrZeroQty = null,
		string pSortBy = null,
		string pItemstarting = null,
		string pItemEnding = null,
		string pProdCodeStarting = null,
		string pProdCodeEnding = null,
		string FromWarehouse = null,
		string ToWarehouse = null,
		byte? DisplayHeader = null,
		byte? CostItemAtWhse = null,
		string pSite = null);
	}
	
	public class Rpt_ItemCosting : IRpt_ItemCosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemCosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCostingSp(string pMatlType = null,
		string pPMTCode = null,
		string pStocked = null,
		string pAbcCode = null,
		byte? pPrZeroQty = null,
		string pSortBy = null,
		string pItemstarting = null,
		string pItemEnding = null,
		string pProdCodeStarting = null,
		string pProdCodeEnding = null,
		string FromWarehouse = null,
		string ToWarehouse = null,
		byte? DisplayHeader = null,
		byte? CostItemAtWhse = null,
		string pSite = null)
		{
			InfobarType _pMatlType = pMatlType;
			InfobarType _pPMTCode = pPMTCode;
			InfobarType _pStocked = pStocked;
			InfobarType _pAbcCode = pAbcCode;
			ListYesNoType _pPrZeroQty = pPrZeroQty;
			InfobarType _pSortBy = pSortBy;
			ItemType _pItemstarting = pItemstarting;
			ItemType _pItemEnding = pItemEnding;
			ProductCodeType _pProdCodeStarting = pProdCodeStarting;
			ProductCodeType _pProdCodeEnding = pProdCodeEnding;
			WhseType _FromWarehouse = FromWarehouse;
			WhseType _ToWarehouse = ToWarehouse;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _CostItemAtWhse = CostItemAtWhse;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemCostingSp";
				
				appDB.AddCommandParameter(cmd, "pMatlType", _pMatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPMTCode", _pPMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStocked", _pStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAbcCode", _pAbcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrZeroQty", _pPrZeroQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSortBy", _pSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemstarting", _pItemstarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemEnding", _pItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProdCodeStarting", _pProdCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProdCodeEnding", _pProdCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWarehouse", _FromWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWarehouse", _ToWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostItemAtWhse", _CostItemAtWhse, ParameterDirection.Input);
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
