//PROJECT NAME: DataCollection
//CLASS NAME: DcCycleSetDefaultLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcCycleSetDefaultLoc : IDcCycleSetDefaultLoc
	{
		readonly IApplicationDB appDB;
		
		
		public DcCycleSetDefaultLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TLoc,
		string TLot,
		string Infobar) DcCycleSetDefaultLocSP(string Item,
		string Whse,
		string DCLot,
		string TLoc,
		string TLot,
		string Infobar)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _DCLot = DCLot;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcCycleSetDefaultLocSP";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCLot", _DCLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TLoc = _TLoc;
				TLot = _TLot;
				Infobar = _Infobar;
				
				return (Severity, TLoc, TLot, Infobar);
			}
		}
	}
}
