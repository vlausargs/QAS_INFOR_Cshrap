//PROJECT NAME: Material
//CLASS NAME: TritemXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITritemXref
	{
		(int? ReturnCode, string CurRefNum, short? CurRefLineSuf, short? CurRefRelease, string Infobar, byte? Warning) TritemXrefSp(string TrnNum,
		short? TrnLine,
		string FrmRefType,
		string FrmRefNum,
		short? FrmRefLineSuf,
		short? FrmRefRelease,
		string Item,
		string ItemDescription,
		string UM,
		string Stat,
		decimal? QtyReq,
		DateTime? SchShipDate,
		DateTime? SchRcvDate,
		string TransferStat,
		string FromWhse,
		byte? PoChangeOrd = (byte)1,
		byte? MpwxrefDelete = (byte)0,
		string CurRefNum = null,
		short? CurRefLineSuf = null,
		short? CurRefRelease = null,
		string Infobar = null,
		string ExportType = null,
		byte? Warning = null);
	}
	
	public class TritemXref : ITritemXref
	{
		readonly IApplicationDB appDB;
		
		public TritemXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurRefNum, short? CurRefLineSuf, short? CurRefRelease, string Infobar, byte? Warning) TritemXrefSp(string TrnNum,
		short? TrnLine,
		string FrmRefType,
		string FrmRefNum,
		short? FrmRefLineSuf,
		short? FrmRefRelease,
		string Item,
		string ItemDescription,
		string UM,
		string Stat,
		decimal? QtyReq,
		DateTime? SchShipDate,
		DateTime? SchRcvDate,
		string TransferStat,
		string FromWhse,
		byte? PoChangeOrd = (byte)1,
		byte? MpwxrefDelete = (byte)0,
		string CurRefNum = null,
		short? CurRefLineSuf = null,
		short? CurRefRelease = null,
		string Infobar = null,
		string ExportType = null,
		byte? Warning = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			RefTypeIJPRType _FrmRefType = FrmRefType;
			JobPoReqNumType _FrmRefNum = FrmRefNum;
			SuffixPoReqLineType _FrmRefLineSuf = FrmRefLineSuf;
			PoReleaseType _FrmRefRelease = FrmRefRelease;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _UM = UM;
			TransferStatusType _Stat = Stat;
			QtyUnitType _QtyReq = QtyReq;
			DateType _SchShipDate = SchShipDate;
			DateType _SchRcvDate = SchRcvDate;
			TransferStatusType _TransferStat = TransferStat;
			WhseType _FromWhse = FromWhse;
			FlagNyType _PoChangeOrd = PoChangeOrd;
			FlagNyType _MpwxrefDelete = MpwxrefDelete;
			JobPoReqNumType _CurRefNum = CurRefNum;
			SuffixPoReqLineType _CurRefLineSuf = CurRefLineSuf;
			PoReleaseType _CurRefRelease = CurRefRelease;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			FlagNyType _Warning = Warning;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TritemXrefSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefType", _FrmRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefNum", _FrmRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefLineSuf", _FrmRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrmRefRelease", _FrmRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchShipDate", _SchShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchRcvDate", _SchRcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferStat", _TransferStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpwxrefDelete", _MpwxrefDelete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurRefNum", _CurRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurRefLineSuf", _CurRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurRefRelease", _CurRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Warning", _Warning, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurRefNum = _CurRefNum;
				CurRefLineSuf = _CurRefLineSuf;
				CurRefRelease = _CurRefRelease;
				Infobar = _Infobar;
				Warning = _Warning;
				
				return (Severity, CurRefNum, CurRefLineSuf, CurRefRelease, Infobar, Warning);
			}
		}
	}
}
