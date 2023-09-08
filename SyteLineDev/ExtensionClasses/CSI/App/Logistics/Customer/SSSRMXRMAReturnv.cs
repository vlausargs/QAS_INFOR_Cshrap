//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXRMAReturnv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXRMAReturnv
	{
		(int? ReturnCode, byte? ParamSuccessFlag, string Infobar, string PromptMsg, string PromptButtons, byte? CallForm) SSSRMXRMAReturnvSp(byte? ParamPostFlag,
		string ParamRmaNum,
		short? ParamRmaLine,
		decimal? ParamQtyToReturnConv,
		decimal? ParamQtyToReturn,
		string ParamLoc,
		string ParamLot,
		byte? ParamSerialConfirmed,
		byte? ParamRtnToStk,
		string ParamReasonCode,
		string ParamWorkkey,
		DateTime? ParamTransDate,
		string ParamTMText,
		byte? ParamSuccessFlag,
		string Infobar,
		string ParamImportDocId,
		decimal? ParamMatlCost = null,
		decimal? ParamLbrCost = null,
		decimal? ParamFovCost = null,
		decimal? ParamVovCost = null,
		decimal? ParamOutCost = null,
		string Container = null,
		string PromptMsg = null,
		string PromptButtons = null,
		byte? CallForm = (byte)0,
		string ParamDocumentNum = null);
	}
	
	public class SSSRMXRMAReturnv : ISSSRMXRMAReturnv
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXRMAReturnv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? ParamSuccessFlag, string Infobar, string PromptMsg, string PromptButtons, byte? CallForm) SSSRMXRMAReturnvSp(byte? ParamPostFlag,
		string ParamRmaNum,
		short? ParamRmaLine,
		decimal? ParamQtyToReturnConv,
		decimal? ParamQtyToReturn,
		string ParamLoc,
		string ParamLot,
		byte? ParamSerialConfirmed,
		byte? ParamRtnToStk,
		string ParamReasonCode,
		string ParamWorkkey,
		DateTime? ParamTransDate,
		string ParamTMText,
		byte? ParamSuccessFlag,
		string Infobar,
		string ParamImportDocId,
		decimal? ParamMatlCost = null,
		decimal? ParamLbrCost = null,
		decimal? ParamFovCost = null,
		decimal? ParamVovCost = null,
		decimal? ParamOutCost = null,
		string Container = null,
		string PromptMsg = null,
		string PromptButtons = null,
		byte? CallForm = (byte)0,
		string ParamDocumentNum = null)
		{
			FlagNyType _ParamPostFlag = ParamPostFlag;
			RmaNumType _ParamRmaNum = ParamRmaNum;
			RmaLineType _ParamRmaLine = ParamRmaLine;
			QtyUnitNoNegType _ParamQtyToReturnConv = ParamQtyToReturnConv;
			QtyUnitNoNegType _ParamQtyToReturn = ParamQtyToReturn;
			LocType _ParamLoc = ParamLoc;
			LotType _ParamLot = ParamLot;
			FlagNyType _ParamSerialConfirmed = ParamSerialConfirmed;
			FlagNyType _ParamRtnToStk = ParamRtnToStk;
			ReasonCodeType _ParamReasonCode = ParamReasonCode;
			LongListType _ParamWorkkey = ParamWorkkey;
			DateTimeType _ParamTransDate = ParamTransDate;
			LongListType _ParamTMText = ParamTMText;
			FlagNyType _ParamSuccessFlag = ParamSuccessFlag;
			InfobarType _Infobar = Infobar;
			StringType _ParamImportDocId = ParamImportDocId;
			CostPrcType _ParamMatlCost = ParamMatlCost;
			CostPrcType _ParamLbrCost = ParamLbrCost;
			CostPrcType _ParamFovCost = ParamFovCost;
			CostPrcType _ParamVovCost = ParamVovCost;
			CostPrcType _ParamOutCost = ParamOutCost;
			ContainerType _Container = Container;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			FlagNyType _CallForm = CallForm;
			DocumentNumType _ParamDocumentNum = ParamDocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRMAReturnvSp";
				
				appDB.AddCommandParameter(cmd, "ParamPostFlag", _ParamPostFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRmaNum", _ParamRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRmaLine", _ParamRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamQtyToReturnConv", _ParamQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamQtyToReturn", _ParamQtyToReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamLoc", _ParamLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamLot", _ParamLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamSerialConfirmed", _ParamSerialConfirmed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRtnToStk", _ParamRtnToStk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamReasonCode", _ParamReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamWorkkey", _ParamWorkkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamTransDate", _ParamTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamTMText", _ParamTMText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamSuccessFlag", _ParamSuccessFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParamImportDocId", _ParamImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamMatlCost", _ParamMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamLbrCost", _ParamLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamFovCost", _ParamFovCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamVovCost", _ParamVovCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamOutCost", _ParamOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Container", _Container, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParamDocumentNum", _ParamDocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ParamSuccessFlag = _ParamSuccessFlag;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				CallForm = _CallForm;
				
				return (Severity, ParamSuccessFlag, Infobar, PromptMsg, PromptButtons, CallForm);
			}
		}
	}
}
