//PROJECT NAME: Data
//CLASS NAME: Event_PurchaseOrderItemReceived.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_PurchaseOrderItemReceived : IEvent_PurchaseOrderItemReceived
	{
		readonly IApplicationDB appDB;
		
		public Event_PurchaseOrderItemReceived(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_PurchaseOrderItemReceivedSp(
			string Item,
			string PoNum,
			string Infobar)
		{
			ItemType _Item = Item;
			PoNumType _PoNum = PoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_PurchaseOrderItemReceivedSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
