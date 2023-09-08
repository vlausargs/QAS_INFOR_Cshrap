//PROJECT NAME: Logistics
//CLASS NAME: TransAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class TransAdd : ITransAdd
	{
		readonly IApplicationDB appDB;
		
		
		public TransAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurTrnNum,
		int? CurTrnLine,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) TransAddSp(string PTrnNum,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PToSite,
		string PToWhse,
		decimal? PQtyOrdered,
		DateTime? PDueDate,
		string PToRefType,
		string PToRefNum,
		int? PToRefLineSuf,
		int? PToRefRelease,
		int? PFromMrpFirm,
		string PRcptsRefNum,
		string CurTrnNum,
		int? CurTrnLine,
		string TrnLoc,
		string FOBSite,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? CreateTransitLoc = 0)
		{
			TrnNumType _PTrnNum = PTrnNum;
			ItemType _PItem = PItem;
			SiteType _PFromSite = PFromSite;
			WhseType _PFromWhse = PFromWhse;
			SiteType _PToSite = PToSite;
			WhseType _PToWhse = PToWhse;
			QtyUnitType _PQtyOrdered = PQtyOrdered;
			DateType _PDueDate = PDueDate;
			RefTypeIJKPRTType _PToRefType = PToRefType;
			CoNumType _PToRefNum = PToRefNum;
			CoLineType _PToRefLineSuf = PToRefLineSuf;
			CoReleaseType _PToRefRelease = PToRefRelease;
			FlagNyType _PFromMrpFirm = PFromMrpFirm;
			UnknownRefNumLastTranType _PRcptsRefNum = PRcptsRefNum;
			TrnNumType _CurTrnNum = CurTrnNum;
			TrnLineType _CurTrnLine = CurTrnLine;
			LocType _TrnLoc = TrnLoc;
			SiteType _FOBSite = FOBSite;
			FlagNyType _ItemLocQuestionAsked = ItemLocQuestionAsked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CreateTransitLoc = CreateTransitLoc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransAddSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromWhse", _PFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToWhse", _PToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefType", _PToRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefNum", _PToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefLineSuf", _PToRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefRelease", _PToRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromMrpFirm", _PFromMrpFirm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRcptsRefNum", _PRcptsRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurTrnNum", _CurTrnNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurTrnLine", _CurTrnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FOBSite", _FOBSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocQuestionAsked", _ItemLocQuestionAsked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateTransitLoc", _CreateTransitLoc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurTrnNum = _CurTrnNum;
				CurTrnLine = _CurTrnLine;
				ItemLocQuestionAsked = _ItemLocQuestionAsked;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, CurTrnNum, CurTrnLine, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
