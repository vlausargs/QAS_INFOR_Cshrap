//PROJECT NAME: Data
//CLASS NAME: InventoryBelowSafetyStock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InventoryBelowSafetyStock : IInventoryBelowSafetyStock
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public InventoryBelowSafetyStock(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) InventoryBelowSafetyStockSp(
			string WarehouseStarting = null,
			string WarehouseENDing = null,
			string ItemStarting = null,
			string ItemENDing = null,
			string ProductCodeStarting = null,
			string ProductCodeENDing = null,
			string PlanCodeStarting = null,
			string PlanCodeENDing = null,
			string MaterialType = null,
			string Source = null,
			string pStocked = null,
			string ABCCode = null,
			int? ExcludeZeroNetRequirements = null,
			int? IncludeTransfers = null,
			int? DisplayHeader = null)
		{
			WhseType _WarehouseStarting = WarehouseStarting;
			WhseType _WarehouseENDing = WarehouseENDing;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemENDing = ItemENDing;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeENDing = ProductCodeENDing;
			UserCodeType _PlanCodeStarting = PlanCodeStarting;
			UserCodeType _PlanCodeENDing = PlanCodeENDing;
			InfobarType _MaterialType = MaterialType;
			InfobarType _Source = Source;
			InfobarType _pStocked = pStocked;
			InfobarType _ABCCode = ABCCode;
			ListYesNoType _ExcludeZeroNetRequirements = ExcludeZeroNetRequirements;
			ListYesNoType _IncludeTransfers = IncludeTransfers;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InventoryBelowSafetyStockSp";
				
				appDB.AddCommandParameter(cmd, "WarehouseStarting", _WarehouseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseENDing", _WarehouseENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemENDing", _ItemENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeENDing", _ProductCodeENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeStarting", _PlanCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeENDing", _PlanCodeENDing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStocked", _pStocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeZeroNetRequirements", _ExcludeZeroNetRequirements, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTransfers", _IncludeTransfers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
