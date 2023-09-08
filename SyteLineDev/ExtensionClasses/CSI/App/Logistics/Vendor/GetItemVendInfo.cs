//PROJECT NAME: CSIVendor
//CLASS NAME: GetItemVendInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetItemVendInfo
	{
		int GetItemVendInfoSp(string CalledFrom,
		                      string VendNum,
		                      ref string Item,
		                      ref string VendItem,
		                      ref string OldVendItem,
		                      ref string VendItemUM,
		                      ref short? LeadTime,
		                      ref byte? ItemVendExists,
		                      ref byte? ItemVendUpdate,
		                      ref string Infobar);
	}
	
	public class GetItemVendInfo : IGetItemVendInfo
	{
		readonly IApplicationDB appDB;
		
		public GetItemVendInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetItemVendInfoSp(string CalledFrom,
		                             string VendNum,
		                             ref string Item,
		                             ref string VendItem,
		                             ref string OldVendItem,
		                             ref string VendItemUM,
		                             ref short? LeadTime,
		                             ref byte? ItemVendExists,
		                             ref byte? ItemVendUpdate,
		                             ref string Infobar)
		{
			StringType _CalledFrom = CalledFrom;
			VendNumType _VendNum = VendNum;
			ItemType _Item = Item;
			VendItemType _VendItem = VendItem;
			VendItemType _OldVendItem = OldVendItem;
			UMType _VendItemUM = VendItemUM;
			LeadTimeType _LeadTime = LeadTime;
			ListYesNoType _ItemVendExists = ItemVendExists;
			ListYesNoType _ItemVendUpdate = ItemVendUpdate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemVendInfoSp";
				
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldVendItem", _OldVendItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendItemUM", _VendItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemVendExists", _ItemVendExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemVendUpdate", _ItemVendUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				VendItem = _VendItem;
				OldVendItem = _OldVendItem;
				VendItemUM = _VendItemUM;
				LeadTime = _LeadTime;
				ItemVendExists = _ItemVendExists;
				ItemVendUpdate = _ItemVendUpdate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
