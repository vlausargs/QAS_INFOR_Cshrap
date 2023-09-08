//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobtranLotValid
	{
		(int? ReturnCode, string OutLot, byte? AddQuestionAsked, byte? ContQuestionAsked, string PromptMsg, string PromptButtons, string Infobar, string TrxRestrictCode) JobtranLotValidSp(string InLot,
		string InItem,
		string RefNum,
		short? RefLine,
		string RefType,
		string OutLot,
		byte? AddQuestionAsked,
		byte? ContQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		byte? PreassignLots = null,
		decimal? Quantity = 0,
		string TrxRestrictCode = null);
	}
	
	public class JobtranLotValid : IJobtranLotValid
	{
		readonly IApplicationDB appDB;
		
		public JobtranLotValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutLot, byte? AddQuestionAsked, byte? ContQuestionAsked, string PromptMsg, string PromptButtons, string Infobar, string TrxRestrictCode) JobtranLotValidSp(string InLot,
		string InItem,
		string RefNum,
		short? RefLine,
		string RefType,
		string OutLot,
		byte? AddQuestionAsked,
		byte? ContQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		byte? PreassignLots = null,
		decimal? Quantity = 0,
		string TrxRestrictCode = null)
		{
			LotType _InLot = InLot;
			ItemType _InItem = InItem;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
			RefTypeIJKOPRSTWType _RefType = RefType;
			LotType _OutLot = OutLot;
			FlagNyType _AddQuestionAsked = AddQuestionAsked;
			FlagNyType _ContQuestionAsked = ContQuestionAsked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PreassignLots = PreassignLots;
			QtyUnitType _Quantity = Quantity;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranLotValidSp";
				
				appDB.AddCommandParameter(cmd, "InLot", _InLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutLot", _OutLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AddQuestionAsked", _AddQuestionAsked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContQuestionAsked", _ContQuestionAsked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Quantity", _Quantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutLot = _OutLot;
				AddQuestionAsked = _AddQuestionAsked;
				ContQuestionAsked = _ContQuestionAsked;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, OutLot, AddQuestionAsked, ContQuestionAsked, PromptMsg, PromptButtons, Infobar, TrxRestrictCode);
			}
		}
	}
}
