//PROJECT NAME: Material
//CLASS NAME: ItemInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemInit : IItemInit
	{
		readonly IApplicationDB appDB;
		
		
		public ItemInit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ItemInitSp(string PItem,
		string PRecordDate,
		decimal? PLastUnitCost,
		decimal? PAvgMatlCost,
		decimal? PAvgLbrCost,
		decimal? PAvgFovhdCost,
		decimal? PAvgVovhdCost,
		decimal? PAvgOutCost,
		decimal? PAvgUnitCost,
		int? PNextConfig,
		decimal? PUsedYTD,
		decimal? PMfgYTD)
		{
			ItemType _PItem = PItem;
			StringType _PRecordDate = PRecordDate;
			CostPrcType _PLastUnitCost = PLastUnitCost;
			CostPrcType _PAvgMatlCost = PAvgMatlCost;
			CostPrcType _PAvgLbrCost = PAvgLbrCost;
			CostPrcType _PAvgFovhdCost = PAvgFovhdCost;
			CostPrcType _PAvgVovhdCost = PAvgVovhdCost;
			CostPrcType _PAvgOutCost = PAvgOutCost;
			CostPrcType _PAvgUnitCost = PAvgUnitCost;
			FeatSuffixType _PNextConfig = PNextConfig;
			QtyCumuType _PUsedYTD = PUsedYTD;
			QtyCumuType _PMfgYTD = PMfgYTD;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemInitSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRecordDate", _PRecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastUnitCost", _PLastUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgMatlCost", _PAvgMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgLbrCost", _PAvgLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgFovhdCost", _PAvgFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgVovhdCost", _PAvgVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgOutCost", _PAvgOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAvgUnitCost", _PAvgUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNextConfig", _PNextConfig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUsedYTD", _PUsedYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMfgYTD", _PMfgYTD, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
