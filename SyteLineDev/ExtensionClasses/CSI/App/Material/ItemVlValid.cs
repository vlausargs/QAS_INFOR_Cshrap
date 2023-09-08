//PROJECT NAME: Material
//CLASS NAME: ItemVlValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemVlValid : IItemVlValid
	{
		readonly IApplicationDB appDB;
		
		
		public ItemVlValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PQty,
		string Infobar) ItemVlValidSp(string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnLot,
		int? PReturn,
		decimal? PQty,
		string Infobar,
		int? UseSite = 0,
		string Site = null)
		{
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PTrnLoc = PTrnLoc;
			LotType _PTrnLot = PTrnLot;
			FlagNyType _PReturn = PReturn;
			QtyUnitType _PQty = PQty;
			InfobarType _Infobar = Infobar;
			FlagNyType _UseSite = UseSite;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemVlValidSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLoc", _PTrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLot", _PTrnLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReturn", _PReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseSite", _UseSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PQty = _PQty;
				Infobar = _Infobar;
				
				return (Severity, PQty, Infobar);
			}
		}
	}
}
