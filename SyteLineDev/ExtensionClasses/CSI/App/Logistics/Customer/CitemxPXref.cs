//PROJECT NAME: Logistics
//CLASS NAME: CitemxPXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CitemxPXref : ICitemxPXref
	{
		readonly IApplicationDB appDB;
		
		public CitemxPXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CurPoNum,
			int? CurPoLine,
			int? CurPoRel,
			string Infobar) CitemxPXrefSp(
			string SourceFile,
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			int? SourceRefRelease,
			string SourceItem,
			string SourceUM,
			string PPoitemWhse,
			string PPoitemRefNum,
			int? PPoitemRefLineSuf,
			int? PPoitemRefRelease,
			decimal? PPoitemQtyOrdered,
			DateTime? PPoitemDueDate,
			string PPoitemRefType,
			string PItemDescription,
			string PStat,
			string PPrefix,
			int? PoChangeOrd,
			string CurPoNum,
			int? CurPoLine,
			int? CurPoRel,
			string Infobar,
			string ExportType)
		{
			InfobarType _SourceFile = SourceFile;
			RefTypeIJPRType _SourceRefType = SourceRefType;
			JobPoReqNumType _SourceRefNum = SourceRefNum;
			SuffixPoReqLineType _SourceRefLineSuf = SourceRefLineSuf;
			PoReleaseType _SourceRefRelease = SourceRefRelease;
			ItemType _SourceItem = SourceItem;
			UMType _SourceUM = SourceUM;
			WhseType _PPoitemWhse = PPoitemWhse;
			JobPoReqNumType _PPoitemRefNum = PPoitemRefNum;
			SuffixPoReqLineType _PPoitemRefLineSuf = PPoitemRefLineSuf;
			PoReleaseType _PPoitemRefRelease = PPoitemRefRelease;
			QtyUnitType _PPoitemQtyOrdered = PPoitemQtyOrdered;
			DateType _PPoitemDueDate = PPoitemDueDate;
			RefTypeIJPRType _PPoitemRefType = PPoitemRefType;
			DescriptionType _PItemDescription = PItemDescription;
			CoitemStatusType _PStat = PStat;
			InfobarType _PPrefix = PPrefix;
			FlagNyType _PoChangeOrd = PoChangeOrd;
			PoNumType _CurPoNum = CurPoNum;
			PoLineType _CurPoLine = CurPoLine;
			PoReleaseType _CurPoRel = CurPoRel;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitemxPXrefSp";
				
				appDB.AddCommandParameter(cmd, "SourceFile", _SourceFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefNum", _SourceRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefLineSuf", _SourceRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefRelease", _SourceRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceItem", _SourceItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceUM", _SourceUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemWhse", _PPoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemRefNum", _PPoitemRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemRefLineSuf", _PPoitemRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemRefRelease", _PPoitemRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemQtyOrdered", _PPoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemDueDate", _PPoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoitemRefType", _PPoitemRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDescription", _PItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrefix", _PPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurPoNum", _CurPoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurPoLine", _CurPoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurPoRel", _CurPoRel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurPoNum = _CurPoNum;
				CurPoLine = _CurPoLine;
				CurPoRel = _CurPoRel;
				Infobar = _Infobar;
				
				return (Severity, CurPoNum, CurPoLine, CurPoRel, Infobar);
			}
		}
	}
}
