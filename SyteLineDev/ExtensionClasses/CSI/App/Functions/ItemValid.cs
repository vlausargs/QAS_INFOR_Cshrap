//PROJECT NAME: Data
//CLASS NAME: ItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemValid : IItemValid
	{
		readonly IApplicationDB appDB;
		
		public ItemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ItemDesc,
			string Infobar,
			int? Kit) ItemValidSp(
			string Item,
			string Whse,
			string ItemDesc,
			string Infobar,
			string Site = null,
			int? Kit = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			DescriptionType _ItemDesc = ItemDesc;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			ListYesNoType _Kit = Kit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemValidSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemDesc = _ItemDesc;
				Infobar = _Infobar;
				Kit = _Kit;
				
				return (Severity, ItemDesc, Infobar, Kit);
			}
		}
	}
}
