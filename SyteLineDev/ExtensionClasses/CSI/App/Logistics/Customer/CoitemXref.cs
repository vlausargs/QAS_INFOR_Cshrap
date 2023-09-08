//PROJECT NAME: CSICustomer
//CLASS NAME: CoitemXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoitemXref
	{
		(int? ReturnCode, string CurRefNum, short? CurRefLineSuf, short? CurRefRelease, byte? ItemLocQuestionAsked, string PromptMsg, string PromptButtons, string Infobar) CoitemXrefSp(string CoNum,
		short? CoLine,
		short? CoRelease,
		string RefType,
		string RefNum,
		short? RefLineSuf,
		short? RefRelease,
		string Item,
		string ItemDescription,
		string UM,
		string CoStat,
		decimal? QtyOrdered,
		DateTime? DueDate,
		string Whse,
		string FromWhse,
		string FromSite,
		string ToSite,
		byte? PoChangeOrd = (byte)1,
		byte? MpwxrefDelete = (byte)0,
		byte? CreateProj = (byte)0,
		byte? CreateProjtask = (byte)0,
		string CurRefNum = null,
		short? CurRefLineSuf = null,
		short? CurRefRelease = null,
		string TrnLoc = null,
		string FOBSite = null,
		byte? ItemLocQuestionAsked = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		string ExportType = null);
	}
	
	public class CoitemXref : ICoitemXref
	{
		readonly IApplicationDB appDB;
		
		public CoitemXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurRefNum, short? CurRefLineSuf, short? CurRefRelease, byte? ItemLocQuestionAsked, string PromptMsg, string PromptButtons, string Infobar) CoitemXrefSp(string CoNum,
		short? CoLine,
		short? CoRelease,
		string RefType,
		string RefNum,
		short? RefLineSuf,
		short? RefRelease,
		string Item,
		string ItemDescription,
		string UM,
		string CoStat,
		decimal? QtyOrdered,
		DateTime? DueDate,
		string Whse,
		string FromWhse,
		string FromSite,
		string ToSite,
		byte? PoChangeOrd = (byte)1,
		byte? MpwxrefDelete = (byte)0,
		byte? CreateProj = (byte)0,
		byte? CreateProjtask = (byte)0,
		string CurRefNum = null,
		short? CurRefLineSuf = null,
		short? CurRefRelease = null,
		string TrnLoc = null,
		string FOBSite = null,
		byte? ItemLocQuestionAsked = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		string ExportType = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			RefTypeIJKPRTType _RefType = RefType;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLineSuf = RefLineSuf;
			OperNumPoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _UM = UM;
			CoStatusType _CoStat = CoStat;
			QtyUnitType _QtyOrdered = QtyOrdered;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			WhseType _FromWhse = FromWhse;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			FlagNyType _PoChangeOrd = PoChangeOrd;
			FlagNyType _MpwxrefDelete = MpwxrefDelete;
			FlagNyType _CreateProj = CreateProj;
			FlagNyType _CreateProjtask = CreateProjtask;
			JobPoReqNumType _CurRefNum = CurRefNum;
			SuffixPoReqLineType _CurRefLineSuf = CurRefLineSuf;
			PoReleaseType _CurRefRelease = CurRefRelease;
			LocType _TrnLoc = TrnLoc;
			SiteType _FOBSite = FOBSite;
			FlagNyType _ItemLocQuestionAsked = ItemLocQuestionAsked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemXrefSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoStat", _CoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpwxrefDelete", _MpwxrefDelete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProj", _CreateProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProjtask", _CreateProjtask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurRefNum", _CurRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurRefLineSuf", _CurRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurRefRelease", _CurRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FOBSite", _FOBSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocQuestionAsked", _ItemLocQuestionAsked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurRefNum = _CurRefNum;
				CurRefLineSuf = _CurRefLineSuf;
				CurRefRelease = _CurRefRelease;
				ItemLocQuestionAsked = _ItemLocQuestionAsked;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, CurRefNum, CurRefLineSuf, CurRefRelease, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
