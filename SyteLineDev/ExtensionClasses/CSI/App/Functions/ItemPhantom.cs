//PROJECT NAME: Data
//CLASS NAME: ItemPhantom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemPhantom : IItemPhantom
	{
		readonly IApplicationDB appDB;
		
		public ItemPhantom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ItemPhantomSp(
			string Item,
			string Component,
			decimal? Actual_Qty)
		{
			ItemType _Item = Item;
			ItemType _Component = Component;
			QtyPerType _Actual_Qty = Actual_Qty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemPhantomSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Component", _Component, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Actual_Qty", _Actual_Qty, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
