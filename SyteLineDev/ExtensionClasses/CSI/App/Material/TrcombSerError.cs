//PROJECT NAME: Material
//CLASS NAME: TrcombSerError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TrcombSerError : ITrcombSerError
	{
		readonly IApplicationDB appDB;
		
		
		public TrcombSerError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) TrcombSerErrorSp(string Site,
		string Item,
		string SerNum,
		int? UseExisting,
		int? SelectFlag = 1,
		string FromSite = null,
		string ToSite = null,
		int? FromSerialTracked = null,
		int? ToSerialTracked = null,
		decimal? QtyShip = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			SiteType _Site = Site;
			ItemType _Item = Item;
			SerNumType _SerNum = SerNum;
			ListYesNoType _UseExisting = UseExisting;
			ListYesNoType _SelectFlag = SelectFlag;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			ListYesNoType _FromSerialTracked = FromSerialTracked;
			ListYesNoType _ToSerialTracked = ToSerialTracked;
			QtyUnitType _QtyShip = QtyShip;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrcombSerErrorSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExisting", _UseExisting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectFlag", _SelectFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSerialTracked", _FromSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSerialTracked", _ToSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShip", _QtyShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
