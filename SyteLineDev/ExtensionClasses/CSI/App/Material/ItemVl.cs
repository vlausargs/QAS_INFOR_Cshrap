//PROJECT NAME: Material
//CLASS NAME: ItemVl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemVl : IItemVl
	{
		readonly IApplicationDB appDB;
		
		
		public ItemVl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PQty,
		string Infobar) ItemVlSp(string PSite,
		string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnLot,
		int? PReturn,
		decimal? PQty,
		string Infobar)
		{
			SiteType _PSite = PSite;
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PTrnLoc = PTrnLoc;
			LotType _PTrnLot = PTrnLot;
			FlagNyType _PReturn = PReturn;
			QtyUnitType _PQty = PQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemVlSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLoc", _PTrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLot", _PTrnLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReturn", _PReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PQty = _PQty;
				Infobar = _Infobar;
				
				return (Severity, PQty, Infobar);
			}
		}
	}
}
