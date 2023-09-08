//PROJECT NAME: Data
//CLASS NAME: ItemGlblAddDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemGlblAddDel : IItemGlblAddDel
	{
		readonly IApplicationDB appDB;
		
		public ItemGlblAddDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemGlblAddDelSp(
			string Item,
			string Site = null,
			string Mode = "ADD",
			string Infobar = null,
			string FromItem = null,
			int? CopyUetValues = 0)
		{
			ItemType _Item = Item;
			SiteType _Site = Site;
			StringType _Mode = Mode;
			InfobarType _Infobar = Infobar;
			ItemType _FromItem = FromItem;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemGlblAddDelSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
