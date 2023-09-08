//PROJECT NAME: DataCollection
//CLASS NAME: SetQtyForInvAdj.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class SetQtyForInvAdj : ISetQtyForInvAdj
	{
		readonly IApplicationDB appDB;
		
		
		public SetQtyForInvAdj(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? QtyOnHand) SetQtyForInvAdjSP(string Item = null,
		string Whse = null,
		string Loc = null,
		string TransType = null,
		decimal? QtyOnHand = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			DcTransTypeType _TransType = TransType;
			QtyUnitNoNegType _QtyOnHand = QtyOnHand;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetQtyForInvAdjSP";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				
				return (Severity, QtyOnHand);
			}
		}
	}
}
