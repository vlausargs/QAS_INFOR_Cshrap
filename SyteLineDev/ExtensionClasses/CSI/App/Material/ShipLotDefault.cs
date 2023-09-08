//PROJECT NAME: Material
//CLASS NAME: ShipLotDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ShipLotDefault : IShipLotDefault
	{
		readonly IApplicationDB appDB;
		
		
		public ShipLotDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Lot,
		string Infobar,
		string ImportDocId) ShipLotDefaultSp(string Site = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Lot = null,
		string Infobar = null,
		string ImportDocId = null)
		{
			SiteType _Site = Site;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipLotDefaultSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Lot = _Lot;
				Infobar = _Infobar;
				ImportDocId = _ImportDocId;
				
				return (Severity, Lot, Infobar, ImportDocId);
			}
		}
	}
}
