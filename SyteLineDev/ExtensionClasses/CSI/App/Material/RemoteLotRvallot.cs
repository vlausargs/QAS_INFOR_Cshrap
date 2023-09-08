//PROJECT NAME: Material
//CLASS NAME: RemoteLotRvallot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class RemoteLotRvallot : IRemoteLotRvallot
	{
		readonly IApplicationDB appDB;
		
		
		public RemoteLotRvallot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string TrxRestrictCode) RemoteLotRvallotSp(string Item,
		string Lot,
		string RemoteSiteLot,
		int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string Site = null,
		string TrxRestrictCode = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			ListExistingCreateBothType _RemoteSiteLot = RemoteSiteLot;
			ByteType _AddLot = AddLot;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteLotRvallotSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLot", _RemoteSiteLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddLot", _AddLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AddLot = _AddLot;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, AddLot, PromptMsg, PromptButtons, Infobar, TrxRestrictCode);
			}
		}
	}
}
