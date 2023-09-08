//PROJECT NAME: Material
//CLASS NAME: ContainerItemQtyUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ContainerItemQtyUpdate : IContainerItemQtyUpdate
	{
		readonly IApplicationDB appDB;
		
		public ContainerItemQtyUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ContainerItemQtyUpdateSp(
			string Whse,
			string Loc,
			string Item,
			string Lot,
			decimal? QtyContained,
			string Infobar)
		{
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ItemType _Item = Item;
			LotType _Lot = Lot;
			QtyUnitNoNegType _QtyContained = QtyContained;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ContainerItemQtyUpdateSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyContained", _QtyContained, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
