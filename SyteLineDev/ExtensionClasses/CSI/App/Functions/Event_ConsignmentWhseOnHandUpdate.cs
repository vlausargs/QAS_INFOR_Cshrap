//PROJECT NAME: Data
//CLASS NAME: Event_ConsignmentWhseOnHandUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_ConsignmentWhseOnHandUpdate : IEvent_ConsignmentWhseOnHandUpdate
	{
		readonly IApplicationDB appDB;
		
		public Event_ConsignmentWhseOnHandUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_ConsignmentWhseOnHandUpdateSp(
			string Item,
			string Whse,
			decimal? QtyOnHand,
			decimal? OldQtyOnHand,
			string Infobar)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			QtyTotlType _QtyOnHand = QtyOnHand;
			QtyTotlType _OldQtyOnHand = OldQtyOnHand;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_ConsignmentWhseOnHandUpdateSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldQtyOnHand", _OldQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
