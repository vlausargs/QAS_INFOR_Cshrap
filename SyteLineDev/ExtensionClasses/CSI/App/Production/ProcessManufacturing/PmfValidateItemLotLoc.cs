//PROJECT NAME: Production
//CLASS NAME: PmfValidateItemLotLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfValidateItemLotLoc : IPmfValidateItemLotLoc
	{
		readonly IApplicationDB appDB;
		
		public PmfValidateItemLotLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			string Lot) PmfValidateItemLotLocSp(
			string InfoBar = null,
			string Item = null,
			string Whse = null,
			string Lot = null,
			string Loc = null)
		{
			InfobarType _InfoBar = InfoBar;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfValidateItemLotLocSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				Lot = _Lot;
				
				return (Severity, InfoBar, Lot);
			}
		}
	}
}
