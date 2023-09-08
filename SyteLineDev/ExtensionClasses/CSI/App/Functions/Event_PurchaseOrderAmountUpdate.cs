//PROJECT NAME: Data
//CLASS NAME: Event_PurchaseOrderAmountUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_PurchaseOrderAmountUpdate : IEvent_PurchaseOrderAmountUpdate
	{
		readonly IApplicationDB appDB;
		
		public Event_PurchaseOrderAmountUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_PurchaseOrderAmountUpdateSp(
			string PoNum,
			string PoCost,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			NameType _PoCost = PoCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_PurchaseOrderAmountUpdateSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoCost", _PoCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
