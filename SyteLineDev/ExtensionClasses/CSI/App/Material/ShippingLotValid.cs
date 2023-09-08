//PROJECT NAME: Material
//CLASS NAME: ShippingLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IShippingLotValid
	{
		(int? ReturnCode, string Infobar, string TrxRestrictCode) ShippingLotValidSp(string Lot,
		                                                                             string Item,
		                                                                             string Whse,
		                                                                             string Loc,
		                                                                             string Action,
		                                                                             string Infobar,
		                                                                             string TrxRestrictCode = null);
	}
	
	public class ShippingLotValid : IShippingLotValid
	{
		readonly IApplicationDB appDB;
		
		public ShippingLotValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string TrxRestrictCode) ShippingLotValidSp(string Lot,
		                                                                                    string Item,
		                                                                                    string Whse,
		                                                                                    string Loc,
		                                                                                    string Action,
		                                                                                    string Infobar,
		                                                                                    string TrxRestrictCode = null)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			InfobarType _Action = Action;
			InfobarType _Infobar = Infobar;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShippingLotValidSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, Infobar, TrxRestrictCode);
			}
		}
	}
}
