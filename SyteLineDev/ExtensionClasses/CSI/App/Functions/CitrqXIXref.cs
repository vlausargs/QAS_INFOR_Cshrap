//PROJECT NAME: Data
//CLASS NAME: CitrqXIXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CitrqXIXref : ICitrqXIXref
	{
		readonly IApplicationDB appDB;
		
		public CitrqXIXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CurReqNum,
			int? CurReqLine,
			string Infobar) CitrqXIXrefSp(
			string SourceFile,
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			int? SourceRefRelease,
			string PWhse,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			decimal? PQtyOrdered,
			DateTime? PDueDate,
			string PRefType,
			string PStat,
			string PStatFldName,
			string PItem,
			string PItemDescription,
			decimal? PItemCurUCost,
			string PItemUM,
			string PPrefix = null,
			int? ObsslowFlag = 0,
			string CurReqNum = null,
			int? CurReqLine = null,
			string Infobar = null)
		{
			InfobarType _SourceFile = SourceFile;
			RefTypeIJPRType _SourceRefType = SourceRefType;
			JobPoReqNumType _SourceRefNum = SourceRefNum;
			SuffixPoReqLineType _SourceRefLineSuf = SourceRefLineSuf;
			PoReleaseType _SourceRefRelease = SourceRefRelease;
			WhseType _PWhse = PWhse;
			JobPoReqNumType _PRefNum = PRefNum;
			SuffixPoReqLineType _PRefLineSuf = PRefLineSuf;
			PoReleaseType _PRefRelease = PRefRelease;
			QtyUnitType _PQtyOrdered = PQtyOrdered;
			DateType _PDueDate = PDueDate;
			RefTypeIJPRType _PRefType = PRefType;
			CoitemStatusType _PStat = PStat;
			InfobarType _PStatFldName = PStatFldName;
			ItemType _PItem = PItem;
			DescriptionType _PItemDescription = PItemDescription;
			CostPrcType _PItemCurUCost = PItemCurUCost;
			UMType _PItemUM = PItemUM;
			InfobarType _PPrefix = PPrefix;
			FlagNyType _ObsslowFlag = ObsslowFlag;
			PoNumType _CurReqNum = CurReqNum;
			PoLineType _CurReqLine = CurReqLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitrqXIXrefSp";
				
				appDB.AddCommandParameter(cmd, "SourceFile", _SourceFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefNum", _SourceRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefLineSuf", _SourceRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefRelease", _SourceRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStatFldName", _PStatFldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemDescription", _PItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemCurUCost", _PItemCurUCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemUM", _PItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrefix", _PPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ObsslowFlag", _ObsslowFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurReqNum", _CurReqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurReqLine", _CurReqLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurReqNum = _CurReqNum;
				CurReqLine = _CurReqLine;
				Infobar = _Infobar;
				
				return (Severity, CurReqNum, CurReqLine, Infobar);
			}
		}
	}
}
