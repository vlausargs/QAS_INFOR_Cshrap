//PROJECT NAME: Material
//CLASS NAME: ItemPlanFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemPlanFlag
	{
		(int? ReturnCode, string Infobar) ItemPlanFlagSp(string Item,
		                                                 string Infobar);
	}
	
	public class ItemPlanFlag : IItemPlanFlag
	{
		readonly IApplicationDB appDB;
		
		public ItemPlanFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemPlanFlagSp(string Item,
		                                                        string Infobar)
		{
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemPlanFlagSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
