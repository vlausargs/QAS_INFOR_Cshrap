//PROJECT NAME: Production
//CLASS NAME: RSQC_QtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_QtyOnHand : IRSQC_QtyOnHand
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_QtyOnHand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? o_qtyonhand,
		string Infobar) RSQC_QtyOnHandSp(string i_item = null,
		string i_whse = null,
		decimal? o_qtyonhand = null,
		string Infobar = null)
		{
			ItemType _i_item = i_item;
			WhseType _i_whse = i_whse;
			QtyUnitType _o_qtyonhand = o_qtyonhand;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_QtyOnHandSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_whse", _i_whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_qtyonhand", _o_qtyonhand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_qtyonhand = _o_qtyonhand;
				Infobar = _Infobar;
				
				return (Severity, o_qtyonhand, Infobar);
			}
		}
	}
}
