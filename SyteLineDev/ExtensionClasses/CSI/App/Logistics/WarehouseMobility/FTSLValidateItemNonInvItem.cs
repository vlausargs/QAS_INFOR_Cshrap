//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateItemNonInvItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateItemNonInvItem
	{
		int FTSLValidateItemNonInvItemSp(string Item,
		                                 ref string ItemDesc,
		                                 ref string IsInventory,
		                                 ref string UM,
		                                 ref byte? SerialTracked,
		                                 ref byte? LotTracked,
		                                 ref byte? GenerateLot,
		                                 ref string Infobar);
	}
	
	public class FTSLValidateItemNonInvItem : IFTSLValidateItemNonInvItem
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateItemNonInvItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateItemNonInvItemSp(string Item,
		                                        ref string ItemDesc,
		                                        ref string IsInventory,
		                                        ref string UM,
		                                        ref byte? SerialTracked,
		                                        ref byte? LotTracked,
		                                        ref byte? GenerateLot,
		                                        ref string Infobar)
		{
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			JobType _IsInventory = IsInventory;
			UMType _UM = UM;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _GenerateLot = GenerateLot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateItemNonInvItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsInventory", _IsInventory, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GenerateLot", _GenerateLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemDesc = _ItemDesc;
				IsInventory = _IsInventory;
				UM = _UM;
				SerialTracked = _SerialTracked;
				LotTracked = _LotTracked;
				GenerateLot = _GenerateLot;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
