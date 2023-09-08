//PROJECT NAME: CSIProjects
//CLASS NAME: PmatlValidateMatlQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IPmatlValidateMatlQty
	{
		(int? ReturnCode, decimal? TQty, string PromptButtons, string PromptMsg, string Infobar, decimal? ConsignQtyRequired, string ConsignVdrWhse, string ConsignVdrLoc, string ConsignedPromptButtons, string ConsignedPromptMsg, string ContianedPromptButtons, string ContianedPromptMsg, string CallFormStr) PmatlValidateMatlQtySp(decimal? NewMatlQty,
		string PWhse,
		string PItem,
		string PLoc,
		string PLot,
		double? UomConvFactor,
		decimal? QtyIssuedConv,
		decimal? QtyRequiredConv,
		byte? CreateMatl,
		decimal? TQty,
		string PromptButtons,
		string PromptMsg,
		string Infobar,
		string PImportDocId,
		string ProjNum = null,
		int? TaskNum = null,
		int? ProjmatSeq = null,
		decimal? ConsignQtyRequired = null,
		string ConsignVdrWhse = null,
		string ConsignVdrLoc = null,
		string ConsignedPromptButtons = null,
		string ConsignedPromptMsg = null,
		string ContianedPromptButtons = null,
		string ContianedPromptMsg = null,
		string CallFormStr = null);
	}
	
	public class PmatlValidateMatlQty : IPmatlValidateMatlQty
	{
		readonly IApplicationDB appDB;
		
		public PmatlValidateMatlQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TQty, string PromptButtons, string PromptMsg, string Infobar, decimal? ConsignQtyRequired, string ConsignVdrWhse, string ConsignVdrLoc, string ConsignedPromptButtons, string ConsignedPromptMsg, string ContianedPromptButtons, string ContianedPromptMsg, string CallFormStr) PmatlValidateMatlQtySp(decimal? NewMatlQty,
		string PWhse,
		string PItem,
		string PLoc,
		string PLot,
		double? UomConvFactor,
		decimal? QtyIssuedConv,
		decimal? QtyRequiredConv,
		byte? CreateMatl,
		decimal? TQty,
		string PromptButtons,
		string PromptMsg,
		string Infobar,
		string PImportDocId,
		string ProjNum = null,
		int? TaskNum = null,
		int? ProjmatSeq = null,
		decimal? ConsignQtyRequired = null,
		string ConsignVdrWhse = null,
		string ConsignVdrLoc = null,
		string ConsignedPromptButtons = null,
		string ConsignedPromptMsg = null,
		string ContianedPromptButtons = null,
		string ContianedPromptMsg = null,
		string CallFormStr = null)
		{
			QtyPerType _NewMatlQty = NewMatlQty;
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			QtyPerType _QtyIssuedConv = QtyIssuedConv;
			QtyPerType _QtyRequiredConv = QtyRequiredConv;
			ListYesNoType _CreateMatl = CreateMatl;
			QtyPerType _TQty = TQty;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _ProjmatSeq = ProjmatSeq;
			QtyTotlType _ConsignQtyRequired = ConsignQtyRequired;
			WhseType _ConsignVdrWhse = ConsignVdrWhse;
			LocType _ConsignVdrLoc = ConsignVdrLoc;
			InfobarType _ConsignedPromptButtons = ConsignedPromptButtons;
			InfobarType _ConsignedPromptMsg = ConsignedPromptMsg;
			InfobarType _ContianedPromptButtons = ContianedPromptButtons;
			InfobarType _ContianedPromptMsg = ContianedPromptMsg;
			InfobarType _CallFormStr = CallFormStr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmatlValidateMatlQtySp";
				
				appDB.AddCommandParameter(cmd, "NewMatlQty", _NewMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyIssuedConv", _QtyIssuedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyRequiredConv", _QtyRequiredConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateMatl", _CreateMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatSeq", _ProjmatSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignQtyRequired", _ConsignQtyRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsignVdrWhse", _ConsignVdrWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsignVdrLoc", _ConsignVdrLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsignedPromptButtons", _ConsignedPromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConsignedPromptMsg", _ConsignedPromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContianedPromptButtons", _ContianedPromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContianedPromptMsg", _ContianedPromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallFormStr", _CallFormStr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TQty = _TQty;
				PromptButtons = _PromptButtons;
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				ConsignQtyRequired = _ConsignQtyRequired;
				ConsignVdrWhse = _ConsignVdrWhse;
				ConsignVdrLoc = _ConsignVdrLoc;
				ConsignedPromptButtons = _ConsignedPromptButtons;
				ConsignedPromptMsg = _ConsignedPromptMsg;
				ContianedPromptButtons = _ContianedPromptButtons;
				ContianedPromptMsg = _ContianedPromptMsg;
				CallFormStr = _CallFormStr;
				
				return (Severity, TQty, PromptButtons, PromptMsg, Infobar, ConsignQtyRequired, ConsignVdrWhse, ConsignVdrLoc, ConsignedPromptButtons, ConsignedPromptMsg, ContianedPromptButtons, ContianedPromptMsg, CallFormStr);
			}
		}
	}
}
