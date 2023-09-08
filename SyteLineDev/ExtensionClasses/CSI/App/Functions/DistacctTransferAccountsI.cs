//PROJECT NAME: Data
//CLASS NAME: DistacctTransferAccountsI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DistacctTransferAccountsI : IDistacctTransferAccountsI
	{
		readonly IApplicationDB appDB;
		
		public DistacctTransferAccountsI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DistacctTransferAccountsISp(
			string DistacctWhse,
			string DistacctProductCode,
			string ItemItem,
			string ItemProductCode,
			string LocType,
			int? ItemlocFound,
			decimal? ItemMatlCost = 0,
			decimal? ItemLbrCost = 0,
			decimal? ItemFovhdCost = 0,
			decimal? ItemVovhdCost = 0,
			decimal? ItemOutCost = 0,
			int? ItemLotTracked = 0,
			string Infobar = null,
			string ItemwhseWhse = null,
			int? CostItemAtWhse = null)
		{
			WhseType _DistacctWhse = DistacctWhse;
			ProductCodeType _DistacctProductCode = DistacctProductCode;
			ItemType _ItemItem = ItemItem;
			ProductCodeType _ItemProductCode = ItemProductCode;
			LocTypeType _LocType = LocType;
			IntType _ItemlocFound = ItemlocFound;
			CostPrcType _ItemMatlCost = ItemMatlCost;
			CostPrcType _ItemLbrCost = ItemLbrCost;
			CostPrcType _ItemFovhdCost = ItemFovhdCost;
			CostPrcType _ItemVovhdCost = ItemVovhdCost;
			CostPrcType _ItemOutCost = ItemOutCost;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			InfobarType _Infobar = Infobar;
			WhseType _ItemwhseWhse = ItemwhseWhse;
			ListYesNoType _CostItemAtWhse = CostItemAtWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DistacctTransferAccountsISp";
				
				appDB.AddCommandParameter(cmd, "DistacctWhse", _DistacctWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistacctProductCode", _DistacctProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemProductCode", _ItemProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocType", _LocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocFound", _ItemlocFound, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemMatlCost", _ItemMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLbrCost", _ItemLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemFovhdCost", _ItemFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemVovhdCost", _ItemVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemOutCost", _ItemOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemwhseWhse", _ItemwhseWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostItemAtWhse", _CostItemAtWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
