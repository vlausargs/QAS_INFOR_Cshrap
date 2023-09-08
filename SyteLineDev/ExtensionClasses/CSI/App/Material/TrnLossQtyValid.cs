//PROJECT NAME: Material
//CLASS NAME: TrnLossQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITrnLossQtyValid
	{
		(int? ReturnCode, string PromptButtons1, string PromptMsg1, string PromptButtons2, string PromptMsg2, string PromptButtons3, string PromptMsg3, string Infobar, byte? CallForm, DateTime? RecordDate) TrnLossQtyValidSp(string TrnNum,
		short? TrnLine,
		double? UmConvFactor,
		decimal? QtyToLoss,
		string FromLoc,
		string FromLot,
		string ToLot,
		string PromptButtons1,
		string PromptMsg1,
		string PromptButtons2,
		string PromptMsg2,
		string PromptButtons3,
		string PromptMsg3,
		string Infobar,
		string ImportDocId,
		byte? CallForm,
		DateTime? RecordDate = null);
	}
	
	public class TrnLossQtyValid : ITrnLossQtyValid
	{
		readonly IApplicationDB appDB;
		
		public TrnLossQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptButtons1, string PromptMsg1, string PromptButtons2, string PromptMsg2, string PromptButtons3, string PromptMsg3, string Infobar, byte? CallForm, DateTime? RecordDate) TrnLossQtyValidSp(string TrnNum,
		short? TrnLine,
		double? UmConvFactor,
		decimal? QtyToLoss,
		string FromLoc,
		string FromLot,
		string ToLot,
		string PromptButtons1,
		string PromptMsg1,
		string PromptButtons2,
		string PromptMsg2,
		string PromptButtons3,
		string PromptMsg3,
		string Infobar,
		string ImportDocId,
		byte? CallForm,
		DateTime? RecordDate = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			UMConvFactorType _UmConvFactor = UmConvFactor;
			QtyUnitType _QtyToLoss = QtyToLoss;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			LotType _ToLot = ToLot;
			InfobarType _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg1 = PromptMsg1;
			InfobarType _PromptButtons2 = PromptButtons2;
			InfobarType _PromptMsg2 = PromptMsg2;
			InfobarType _PromptButtons3 = PromptButtons3;
			InfobarType _PromptMsg3 = PromptMsg3;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _CallForm = CallForm;
			CurrentDateType _RecordDate = RecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnLossQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UmConvFactor", _UmConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToLoss", _QtyToLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons3", _PromptButtons3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg3", _PromptMsg3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptButtons1 = _PromptButtons1;
				PromptMsg1 = _PromptMsg1;
				PromptButtons2 = _PromptButtons2;
				PromptMsg2 = _PromptMsg2;
				PromptButtons3 = _PromptButtons3;
				PromptMsg3 = _PromptMsg3;
				Infobar = _Infobar;
				CallForm = _CallForm;
				RecordDate = _RecordDate;
				
				return (Severity, PromptButtons1, PromptMsg1, PromptButtons2, PromptMsg2, PromptButtons3, PromptMsg3, Infobar, CallForm, RecordDate);
			}
		}
	}
}
