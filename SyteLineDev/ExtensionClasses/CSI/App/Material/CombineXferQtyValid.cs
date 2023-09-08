//PROJECT NAME: CSIMaterial
//CLASS NAME: CombineXferQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ICombineXferQtyValid
	{
		(int? ReturnCode, string QtyGtPromptMsg, string QtyGtPromptButtons, string DetailPromptMsg, string DetailPromptButtons, string Detail2PromptMsg, string Detail2PromptButtons, string Infobar, byte? CallForm, DateTime? RecordDate) CombineXferQtyValidSp(decimal? TQtyShipped,
		string TUM,
		byte? ItemSerialTracked,
		string TrnNum,
		short? TrnLine,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		string FromLoc,
		string ToLoc,
		string FromLot,
		string ToLot,
		string Item,
		string QtyGtPromptMsg,
		string QtyGtPromptButtons,
		string DetailPromptMsg,
		string DetailPromptButtons,
		string Detail2PromptMsg,
		string Detail2PromptButtons,
		string Infobar,
		string ImportDocId,
		byte? CallForm,
		DateTime? RecordDate = null);
	}
	
	public class CombineXferQtyValid : ICombineXferQtyValid
	{
		readonly IApplicationDB appDB;
		
		public CombineXferQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string QtyGtPromptMsg, string QtyGtPromptButtons, string DetailPromptMsg, string DetailPromptButtons, string Detail2PromptMsg, string Detail2PromptButtons, string Infobar, byte? CallForm, DateTime? RecordDate) CombineXferQtyValidSp(decimal? TQtyShipped,
		string TUM,
		byte? ItemSerialTracked,
		string TrnNum,
		short? TrnLine,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		string FromLoc,
		string ToLoc,
		string FromLot,
		string ToLot,
		string Item,
		string QtyGtPromptMsg,
		string QtyGtPromptButtons,
		string DetailPromptMsg,
		string DetailPromptButtons,
		string Detail2PromptMsg,
		string Detail2PromptButtons,
		string Infobar,
		string ImportDocId,
		byte? CallForm,
		DateTime? RecordDate = null)
		{
			QtyUnitType _TQtyShipped = TQtyShipped;
			UMType _TUM = TUM;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			LocType _FromLoc = FromLoc;
			LocType _ToLoc = ToLoc;
			LotType _FromLot = FromLot;
			LotType _ToLot = ToLot;
			ItemType _Item = Item;
			InfobarType _QtyGtPromptMsg = QtyGtPromptMsg;
			InfobarType _QtyGtPromptButtons = QtyGtPromptButtons;
			InfobarType _DetailPromptMsg = DetailPromptMsg;
			InfobarType _DetailPromptButtons = DetailPromptButtons;
			InfobarType _Detail2PromptMsg = Detail2PromptMsg;
			InfobarType _Detail2PromptButtons = Detail2PromptButtons;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _CallForm = CallForm;
			CurrentDateType _RecordDate = RecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "TQtyShipped", _TQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyGtPromptMsg", _QtyGtPromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyGtPromptButtons", _QtyGtPromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DetailPromptMsg", _DetailPromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DetailPromptButtons", _DetailPromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Detail2PromptMsg", _Detail2PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Detail2PromptButtons", _Detail2PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyGtPromptMsg = _QtyGtPromptMsg;
				QtyGtPromptButtons = _QtyGtPromptButtons;
				DetailPromptMsg = _DetailPromptMsg;
				DetailPromptButtons = _DetailPromptButtons;
				Detail2PromptMsg = _Detail2PromptMsg;
				Detail2PromptButtons = _Detail2PromptButtons;
				Infobar = _Infobar;
				CallForm = _CallForm;
				RecordDate = _RecordDate;
				
				return (Severity, QtyGtPromptMsg, QtyGtPromptButtons, DetailPromptMsg, DetailPromptButtons, Detail2PromptMsg, Detail2PromptButtons, Infobar, CallForm, RecordDate);
			}
		}
	}
}
