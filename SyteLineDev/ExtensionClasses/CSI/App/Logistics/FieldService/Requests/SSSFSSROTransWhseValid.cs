//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransWhseValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransWhseValid
	{
		(int? ReturnCode, string Whse,
		string Lot,
		string Loc,
		string Infobar,
		string TrxRestrictCode) SSSFSSROTransWhseValidSp(string Item,
		string Whse,
		string Lot,
		string Loc,
		string Infobar,
		string TrxRestrictCode = null);
	}
	
	public class SSSFSSROTransWhseValid : ISSSFSSROTransWhseValid
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransWhseValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Whse,
		string Lot,
		string Loc,
		string Infobar,
		string TrxRestrictCode) SSSFSSROTransWhseValidSp(string Item,
		string Whse,
		string Lot,
		string Loc,
		string Infobar,
		string TrxRestrictCode = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			InfobarType _Infobar = Infobar;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransWhseValidSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Whse = _Whse;
				Lot = _Lot;
				Loc = _Loc;
				Infobar = _Infobar;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, Whse, Lot, Loc, Infobar, TrxRestrictCode);
			}
		}
	}
}
