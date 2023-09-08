//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefCreate : ISSSFSXrefCreate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSXrefCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRelease,
		string Infobar) SSSFSXrefCreateSp(string FromRefType,
		string FromRefNum,
		int? FromRefLineSuf,
		int? FromRefRelease,
		int? FromTransNum,
		string ToRefType,
		string ToRefNum,
		int? ToRefLineSuf,
		int? ToRefRelease,
		string CustNum,
		string Item,
		string ItemDescription,
		string UM,
		DateTime? DueDate,
		string Whse,
		string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRelease,
		string Infobar,
		string FromWhse = null,
		string FromSite = null,
		string ToSite = null,
		int? PoChangeOrd = 1,
		int? MpwxrefDelete = 0,
		int? CreateProj = 0,
		int? CreateProjtask = 0,
		string TrnLoc = null,
		string FOBSite = null,
		int? CustSeq = 0)
		{
			StringType _FromRefType = FromRefType;
			CoNumType _FromRefNum = FromRefNum;
			CoLineType _FromRefLineSuf = FromRefLineSuf;
			CoReleaseType _FromRefRelease = FromRefRelease;
			FSSROTransNumType _FromTransNum = FromTransNum;
			RefTypeIJKPRTType _ToRefType = ToRefType;
			JobPoProjReqTrnNumType _ToRefNum = ToRefNum;
			SuffixPoLineProjTaskReqTrnLineType _ToRefLineSuf = ToRefLineSuf;
			OperNumPoReleaseType _ToRefRelease = ToRefRelease;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _UM = UM;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			JobPoReqNumType _NewRefNum = NewRefNum;
			SuffixPoReqLineType _NewRefLineSuf = NewRefLineSuf;
			PoReleaseType _NewRefRelease = NewRefRelease;
			InfobarType _Infobar = Infobar;
			WhseType _FromWhse = FromWhse;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			FlagNyType _PoChangeOrd = PoChangeOrd;
			FlagNyType _MpwxrefDelete = MpwxrefDelete;
			FlagNyType _CreateProj = CreateProj;
			FlagNyType _CreateProjtask = CreateProjtask;
			LocType _TrnLoc = TrnLoc;
			SiteType _FOBSite = FOBSite;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefCreateSp";
				
				appDB.AddCommandParameter(cmd, "FromRefType", _FromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefNum", _FromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefLineSuf", _FromRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRefRelease", _FromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefType", _ToRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefNum", _ToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefLineSuf", _ToRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRefRelease", _ToRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewRefNum", _NewRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewRefLineSuf", _NewRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewRefRelease", _NewRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpwxrefDelete", _MpwxrefDelete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProj", _CreateProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateProjtask", _CreateProjtask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FOBSite", _FOBSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewRefNum = _NewRefNum;
				NewRefLineSuf = _NewRefLineSuf;
				NewRefRelease = _NewRefRelease;
				Infobar = _Infobar;
				
				return (Severity, NewRefNum, NewRefLineSuf, NewRefRelease, Infobar);
			}
		}
	}
}
