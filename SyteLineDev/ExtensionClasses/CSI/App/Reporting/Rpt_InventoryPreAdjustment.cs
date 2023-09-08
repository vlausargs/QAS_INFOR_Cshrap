//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryPreAdjustment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InventoryPreAdjustment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryPreAdjustmentSp(string ExOptszVarSelect = "B",
		decimal? ExOptprQtyVar = 0,
		decimal? ExOptSzCostVar = 0,
		byte? ExOptszSortByProdcode = (byte)0,
		string ExOptprProductCode = null,
		string ExOptprPlanCode = null,
		string Whse = null,
		byte? PDisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_InventoryPreAdjustment : IRpt_InventoryPreAdjustment
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InventoryPreAdjustment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryPreAdjustmentSp(string ExOptszVarSelect = "B",
		decimal? ExOptprQtyVar = 0,
		decimal? ExOptSzCostVar = 0,
		byte? ExOptszSortByProdcode = (byte)0,
		string ExOptprProductCode = null,
		string ExOptprPlanCode = null,
		string Whse = null,
		byte? PDisplayHeader = (byte)1,
		string pSite = null)
		{
			InfobarType _ExOptszVarSelect = ExOptszVarSelect;
			QtyPerType _ExOptprQtyVar = ExOptprQtyVar;
			CostPrcType _ExOptSzCostVar = ExOptSzCostVar;
			ListYesNoType _ExOptszSortByProdcode = ExOptszSortByProdcode;
			ProductCodeType _ExOptprProductCode = ExOptprProductCode;
			UserCodeType _ExOptprPlanCode = ExOptprPlanCode;
			WhseType _Whse = Whse;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InventoryPreAdjustmentSp";
				
				appDB.AddCommandParameter(cmd, "ExOptszVarSelect", _ExOptszVarSelect, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprQtyVar", _ExOptprQtyVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptSzCostVar", _ExOptSzCostVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSortByProdcode", _ExOptszSortByProdcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprProductCode", _ExOptprProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPlanCode", _ExOptprPlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
