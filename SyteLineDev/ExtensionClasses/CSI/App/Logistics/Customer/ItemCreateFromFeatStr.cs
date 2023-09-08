//PROJECT NAME: Logistics
//CLASS NAME: ItemCreateFromFeatStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ItemCreateFromFeatStr : IItemCreateFromFeatStr
	{
		readonly IApplicationDB appDB;
		
		
		public ItemCreateFromFeatStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NewItem,
		string Infobar) ItemCreateFromFeatStrSp(string FeatStr,
		string Item,
		string CurrCode,
		decimal? ContractPrice,
		string CoNum,
		int? CoLine,
		decimal? IncPrice,
		string NewItem,
		string Infobar,
		string Site = null)
		{
			FeatStrType _FeatStr = FeatStr;
			ItemType _Item = Item;
			CurrCodeType _CurrCode = CurrCode;
			CostPrcType _ContractPrice = ContractPrice;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CostPrcType _IncPrice = IncPrice;
			ItemType _NewItem = NewItem;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCreateFromFeatStrSp";
				
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractPrice", _ContractPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncPrice", _IncPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewItem = _NewItem;
				Infobar = _Infobar;
				
				return (Severity, NewItem, Infobar);
			}
		}
	}
}
