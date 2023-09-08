//PROJECT NAME: Material
//CLASS NAME: RebalItemOnPurchaseOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class RebalItemOnPurchaseOrder : IRebalItemOnPurchaseOrder
	{
		readonly IApplicationDB appDB;
		
		
		public RebalItemOnPurchaseOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RebalItemOnPurchaseOrderSp(string Infobar,
		string StartingItem = null,
		string EndingItem = null,
		string StartingWhse = null,
		string EndingWhse = null)
		{
			InfobarType _Infobar = Infobar;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			WhseType _StartingWhse = StartingWhse;
			WhseType _EndingWhse = EndingWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RebalItemOnPurchaseOrderSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingWhse", _StartingWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWhse", _EndingWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
