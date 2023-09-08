//PROJECT NAME: DataCollection
//CLASS NAME: DcCycleValLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcCycleValLoc : IDcCycleValLoc
	{
		readonly IApplicationDB appDB;
		
		
		public DcCycleValLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) DcCycleValLocSP(string DCItemItem,
		string DCItemWhse,
		string DCItemLoc,
		string DCItemLot,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			ItemType _DCItemItem = DCItemItem;
			WhseType _DCItemWhse = DCItemWhse;
			LocType _DCItemLoc = DCItemLoc;
			LotType _DCItemLot = DCItemLot;
			FlagNyType _ItemLocQuestionAsked = ItemLocQuestionAsked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcCycleValLocSP";
				
				appDB.AddCommandParameter(cmd, "DCItemItem", _DCItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCItemWhse", _DCItemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCItemLoc", _DCItemLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCItemLot", _DCItemLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocQuestionAsked", _ItemLocQuestionAsked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemLocQuestionAsked = _ItemLocQuestionAsked;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
