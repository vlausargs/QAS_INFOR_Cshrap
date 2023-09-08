//PROJECT NAME: Material
//CLASS NAME: TrrcvSerError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TrrcvSerError : ITrrcvSerError
	{
		readonly IApplicationDB appDB;
		
		
		public TrrcvSerError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) TrrcvSerErrorSp(string Site,
		string Item,
		string SerNum,
		int? UseExisting,
		int? SelectFlag = 1,
		string FromSite = null,
		string ToSite = null,
		string FobSite = null,
		int? FromSerialTracked = null,
		int? ToSerialTracked = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		decimal? QtyReceived = null)
		{
			SiteType _Site = Site;
			ItemType _Item = Item;
			SerNumType _SerNum = SerNum;
			ListYesNoType _UseExisting = UseExisting;
			ListYesNoType _SelectFlag = SelectFlag;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			SiteType _FobSite = FobSite;
			ListYesNoType _FromSerialTracked = FromSerialTracked;
			ListYesNoType _ToSerialTracked = ToSerialTracked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			QtyUnitType _QtyReceived = QtyReceived;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrrcvSerErrorSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExisting", _UseExisting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectFlag", _SelectFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FobSite", _FobSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSerialTracked", _FromSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSerialTracked", _ToSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
