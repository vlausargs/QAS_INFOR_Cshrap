//PROJECT NAME: Data
//CLASS NAME: Event_PurchaseOrderRequisitionAmountUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_PurchaseOrderRequisitionAmountUpdate : IEvent_PurchaseOrderRequisitionAmountUpdate
	{
		readonly IApplicationDB appDB;
		
		public Event_PurchaseOrderRequisitionAmountUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_PurchaseOrderRequisitionAmountUpdateSp(
			string ReqNum,
			decimal? ReqCost,
			string Infobar)
		{
			ReqNumType _ReqNum = ReqNum;
			AmountType _ReqCost = ReqCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_PurchaseOrderRequisitionAmountUpdateSp";
				
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqCost", _ReqCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
