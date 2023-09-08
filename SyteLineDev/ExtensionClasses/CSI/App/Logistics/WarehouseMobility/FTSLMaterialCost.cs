//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLMaterialCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLMaterialCost
	{
		int FTSLMaterialCostSp(string Item,
		                       ref string Infobar);
	}
	
	public class FTSLMaterialCost : IFTSLMaterialCost
	{
		readonly IApplicationDB appDB;
		
		public FTSLMaterialCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLMaterialCostSp(string Item,
		                              ref string Infobar)
		{
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLMaterialCostSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
