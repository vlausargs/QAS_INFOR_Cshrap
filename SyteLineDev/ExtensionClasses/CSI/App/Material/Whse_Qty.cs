//PROJECT NAME: Material
//CLASS NAME: Whse_Qty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Whse_Qty : IWhse_Qty
	{
		readonly IApplicationDB appDB;
		
		public Whse_Qty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? p_on_hand) Whse_QtySp(
			string p_mrp_whse,
			string p_whse,
			string p_item,
			decimal? p_on_hand)
		{
			ListSingleAllType _p_mrp_whse = p_mrp_whse;
			WhseType _p_whse = p_whse;
			ItemType _p_item = p_item;
			QtyTotlType _p_on_hand = p_on_hand;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Whse_QtySp";
				
				appDB.AddCommandParameter(cmd, "p_mrp_whse", _p_mrp_whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_whse", _p_whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_item", _p_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_on_hand", _p_on_hand, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				p_on_hand = _p_on_hand;
				
				return (Severity, p_on_hand);
			}
		}
	}
}
