//PROJECT NAME: Material
//CLASS NAME: RValLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class RValLot : IRValLot
	{
		readonly IApplicationDB appDB;
		
		
		public RValLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Lot,
		int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string TrxRestrictCode) RValLotSP(string Item,
		string Lot,
		int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string Site = null,
		decimal? Quantity = null,
		string TrxRestrictCode = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			ByteType _AddLot = AddLot;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			QtyUnitType _Quantity = Quantity;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RValLotSP";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AddLot", _AddLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Quantity", _Quantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Lot = _Lot;
				AddLot = _AddLot;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, Lot, AddLot, PromptMsg, PromptButtons, Infobar, TrxRestrictCode);
			}
		}
	}
}
