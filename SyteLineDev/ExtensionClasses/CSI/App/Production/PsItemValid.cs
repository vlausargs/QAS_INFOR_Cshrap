//PROJECT NAME: Production
//CLASS NAME: PsItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PsItemValid : IPsItemValid
	{
		readonly IApplicationDB appDB;
		
		
		public PsItemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string TItemDesc,
		int? TSerTracked,
		int? TLotTracked,
		string TLotPrefix,
		string TLoc,
		string TLot,
		string TUM,
		decimal? UomConvFactor,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? EnableContainer) PsItemValidSp(string Item,
		string Whse,
		string TItemDesc,
		int? TSerTracked,
		int? TLotTracked,
		string TLotPrefix,
		string TLoc,
		string TLot,
		string TUM,
		decimal? UomConvFactor,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? EnableContainer = 0)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			DescriptionType _TItemDesc = TItemDesc;
			ListYesNoType _TSerTracked = TSerTracked;
			ListYesNoType _TLotTracked = TLotTracked;
			LotPrefixType _TLotPrefix = TLotPrefix;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			UMType _TUM = TUM;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _EnableContainer = EnableContainer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PsItemValidSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItemDesc", _TItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSerTracked", _TSerTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLotTracked", _TLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLotPrefix", _TLotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableContainer", _EnableContainer, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				TItemDesc = _TItemDesc;
				TSerTracked = _TSerTracked;
				TLotTracked = _TLotTracked;
				TLotPrefix = _TLotPrefix;
				TLoc = _TLoc;
				TLot = _TLot;
				TUM = _TUM;
				UomConvFactor = _UomConvFactor;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				EnableContainer = _EnableContainer;
				
				return (Severity, Item, TItemDesc, TSerTracked, TLotTracked, TLotPrefix, TLoc, TLot, TUM, UomConvFactor, PromptMsg, PromptButtons, Infobar, EnableContainer);
			}
		}
	}
}
