//PROJECT NAME: Material
//CLASS NAME: ItemPortalPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemPortalPrice : IItemPortalPrice
	{
		readonly IApplicationDB appDB;
		
		
		public ItemPortalPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemPortalPriceSp(string StartingItem,
		string EndingItem,
		string Infobar = null,
		int? BGTaskID = null)
		{
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			InfobarType _Infobar = Infobar;
			GenericNoType _BGTaskID = BGTaskID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemPortalPriceSp";
				
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BGTaskID", _BGTaskID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
