//PROJECT NAME: Material
//CLASS NAME: TrrcvQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITrrcvQtyValid
	{
		(int? ReturnCode, string PromptMsg1, string PromptButtons1, string PromptMsg2, string PromptButtons2, string PromptMsg3, string PromptButtons3, string Infobar, byte? CallForm, DateTime? RecordDate) TrrcvQtyValidSp(string TrnNum,
		short? TrnLine,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		double? UmConvFactor,
		decimal? QtyReceived,
		string TrnLoc,
		string FromLot,
		string ToLoc,
		string ToLot,
		string Item,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string Infobar,
		string ImportDocId,
		byte? CallForm,
		DateTime? RecordDate = null);
	}
	
	public class TrrcvQtyValid : ITrrcvQtyValid
	{
		readonly IApplicationDB appDB;
		
		public TrrcvQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg1, string PromptButtons1, string PromptMsg2, string PromptButtons2, string PromptMsg3, string PromptButtons3, string Infobar, byte? CallForm, DateTime? RecordDate) TrrcvQtyValidSp(string TrnNum,
		short? TrnLine,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		double? UmConvFactor,
		decimal? QtyReceived,
		string TrnLoc,
		string FromLot,
		string ToLoc,
		string ToLot,
		string Item,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string Infobar,
		string ImportDocId,
		byte? CallForm,
		DateTime? RecordDate = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			UMConvFactorType _UmConvFactor = UmConvFactor;
			QtyUnitType _QtyReceived = QtyReceived;
			LocType _TrnLoc = TrnLoc;
			LotType _FromLot = FromLot;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			ItemType _Item = Item;
			InfobarType _PromptMsg1 = PromptMsg1;
			InfobarType _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg2 = PromptMsg2;
			InfobarType _PromptButtons2 = PromptButtons2;
			InfobarType _PromptMsg3 = PromptMsg3;
			InfobarType _PromptButtons3 = PromptButtons3;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _CallForm = CallForm;
			CurrentDateType _RecordDate = RecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrrcvQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UmConvFactor", _UmConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg3", _PromptMsg3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons3", _PromptButtons3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg1 = _PromptMsg1;
				PromptButtons1 = _PromptButtons1;
				PromptMsg2 = _PromptMsg2;
				PromptButtons2 = _PromptButtons2;
				PromptMsg3 = _PromptMsg3;
				PromptButtons3 = _PromptButtons3;
				Infobar = _Infobar;
				CallForm = _CallForm;
				RecordDate = _RecordDate;
				
				return (Severity, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, PromptMsg3, PromptButtons3, Infobar, CallForm, RecordDate);
			}
		}
	}
}
