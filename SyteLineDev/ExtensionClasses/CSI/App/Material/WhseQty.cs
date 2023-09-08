//PROJECT NAME: Material
//CLASS NAME: WhseQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class WhseQty : IWhseQty
	{
		readonly IApplicationDB appDB;
		
		public WhseQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PReorder,
			decimal? POnHand,
			string Infobar) WhseQtySp(
			string PItem,
			decimal? PReorder,
			decimal? POnHand,
			string Infobar)
		{
			ItemType _PItem = PItem;
			QtyUnitType _PReorder = PReorder;
			QtyTotlType _POnHand = POnHand;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WhseQtySp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReorder", _PReorder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POnHand", _POnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReorder = _PReorder;
				POnHand = _POnHand;
				Infobar = _Infobar;
				
				return (Severity, PReorder, POnHand, Infobar);
			}
		}
	}
}
