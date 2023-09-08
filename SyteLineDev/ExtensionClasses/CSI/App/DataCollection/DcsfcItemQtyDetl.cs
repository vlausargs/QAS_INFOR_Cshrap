//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcItemQtyDetl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcItemQtyDetl : IDcsfcItemQtyDetl
	{
		readonly IApplicationDB appDB;
		
		public DcsfcItemQtyDetl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DcsfcItemQtyDetlSp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			decimal? DeltaQty,
			int? Override,
			string Infobar)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitNoNegType _DeltaQty = DeltaQty;
			FlagNyType _Override = Override;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcsfcItemQtyDetlSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeltaQty", _DeltaQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Override", _Override, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
