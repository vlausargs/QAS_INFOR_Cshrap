//PROJECT NAME: Material
//CLASS NAME: ItemTracked.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemTracked : IItemTracked
	{
		readonly IApplicationDB appDB;
		
		
		public ItemTracked(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SerialTracked,
		int? LotTracked,
		string Infobar) ItemTrackedSp(string Item,
		int? SerialTracked,
		int? LotTracked,
		string Infobar)
		{
			ItemType _Item = Item;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _LotTracked = LotTracked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemTrackedSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerialTracked = _SerialTracked;
				LotTracked = _LotTracked;
				Infobar = _Infobar;
				
				return (Severity, SerialTracked, LotTracked, Infobar);
			}
		}
	}
}
