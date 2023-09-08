//PROJECT NAME: Material
//CLASS NAME: PhyinvLotV1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PhyinvLotV1 : IPhyinvLotV1
	{
		readonly IApplicationDB appDB;
		
		
		public PhyinvLotV1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? LotEnable,
		string Infobar,
		string Revision) PhyinvLotV1Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		int? LotEnable,
		string Infobar,
		string Revision = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ListYesNoType _LotEnable = LotEnable;
			Infobar _Infobar = Infobar;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyinvLotV1Sp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotEnable", _LotEnable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotEnable = _LotEnable;
				Infobar = _Infobar;
				Revision = _Revision;
				
				return (Severity, LotEnable, Infobar, Revision);
			}
		}
	}
}
