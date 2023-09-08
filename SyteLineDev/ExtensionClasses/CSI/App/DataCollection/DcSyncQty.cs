//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcSyncQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcSyncQty
	{
		int DcSyncQtySp(string DCitemTransType,
		                decimal? DCitemRepQty,
		                decimal? DCitemCountQty,
		                ref decimal? TcQttQtyOnHand,
		                string DCitemItem,
		                string DCitemUM,
		                int? DcitemTransNum,
		                ref byte? AskQuestion,
		                ref byte? UpdtCountQtyFlag,
		                ref decimal? UpdtCountQty,
		                ref string PromptMsg,
		                ref string PromptButtons,
		                ref string Infobar);
	}
	
	public class DcSyncQty : IDcSyncQty
	{
		readonly IApplicationDB appDB;
		
		public DcSyncQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DcSyncQtySp(string DCitemTransType,
		                       decimal? DCitemRepQty,
		                       decimal? DCitemCountQty,
		                       ref decimal? TcQttQtyOnHand,
		                       string DCitemItem,
		                       string DCitemUM,
		                       int? DcitemTransNum,
		                       ref byte? AskQuestion,
		                       ref byte? UpdtCountQtyFlag,
		                       ref decimal? UpdtCountQty,
		                       ref string PromptMsg,
		                       ref string PromptButtons,
		                       ref string Infobar)
		{
			DcTransTypeType _DCitemTransType = DCitemTransType;
			QtyUnitNoNegType _DCitemRepQty = DCitemRepQty;
			QtyUnitNoNegType _DCitemCountQty = DCitemCountQty;
			QtyUnitNoNegType _TcQttQtyOnHand = TcQttQtyOnHand;
			ItemType _DCitemItem = DCitemItem;
			UMType _DCitemUM = DCitemUM;
			DcTransNumType _DcitemTransNum = DcitemTransNum;
			ListYesNoType _AskQuestion = AskQuestion;
			ListYesNoType _UpdtCountQtyFlag = UpdtCountQtyFlag;
			QtyUnitNoNegType _UpdtCountQty = UpdtCountQty;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcSyncQtySp";
				
				appDB.AddCommandParameter(cmd, "DCitemTransType", _DCitemTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCitemRepQty", _DCitemRepQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCitemCountQty", _DCitemCountQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcQttQtyOnHand", _TcQttQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DCitemItem", _DCitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCitemUM", _DCitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcitemTransNum", _DcitemTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AskQuestion", _AskQuestion, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UpdtCountQtyFlag", _UpdtCountQtyFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UpdtCountQty", _UpdtCountQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcQttQtyOnHand = _TcQttQtyOnHand;
				AskQuestion = _AskQuestion;
				UpdtCountQtyFlag = _UpdtCountQtyFlag;
				UpdtCountQty = _UpdtCountQty;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
