//PROJECT NAME: Data
//CLASS NAME: CitrqXI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CitrqXI : ICitrqXI
	{
		readonly IApplicationDB appDB;
		
		public CitrqXI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) CitrqXISp(
			string SourceFile,
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			int? SourceRefRelease,
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
			string PPrefix,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			InfobarType _SourceFile = SourceFile;
			RefTypeIJPRType _SourceRefType = SourceRefType;
			JobPoReqNumType _SourceRefNum = SourceRefNum;
			SuffixPoReqLineType _SourceRefLineSuf = SourceRefLineSuf;
			PoReleaseType _SourceRefRelease = SourceRefRelease;
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
			InfobarType _TXrefDestination = TXrefDestination;
			FlagNyType _CreateFlag = CreateFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitrqXISp";
				
				appDB.AddCommandParameter(cmd, "SourceFile", _SourceFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefNum", _SourceRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefLineSuf", _SourceRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceRefRelease", _SourceRefRelease, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "TXrefDestination", _TXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TXrefDestination = _TXrefDestination;
				CreateFlag = _CreateFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, TXrefDestination, CreateFlag, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
