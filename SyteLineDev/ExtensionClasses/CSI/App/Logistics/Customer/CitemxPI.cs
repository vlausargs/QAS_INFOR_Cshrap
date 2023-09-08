//PROJECT NAME: Logistics
//CLASS NAME: CitemxPI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CitemxPI : ICitemxPI
	{
		readonly IApplicationDB appDB;
		
		public CitemxPI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) CitemxPISp(
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
			string ItemDescription,
			string Stat,
			string Prefix,
			string PXrefDestination,
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
			ItemType _SourceItem = SourceItem;
			UMType _SourceUM = SourceUM;
			WhseType _PPoitemWhse = PPoitemWhse;
			JobPoReqNumType _PPoitemRefNum = PPoitemRefNum;
			SuffixPoReqLineType _PPoitemRefLineSuf = PPoitemRefLineSuf;
			PoReleaseType _PPoitemRefRelease = PPoitemRefRelease;
			QtyUnitType _PPoitemQtyOrdered = PPoitemQtyOrdered;
			DateType _PPoitemDueDate = PPoitemDueDate;
			RefTypeIJPRType _PPoitemRefType = PPoitemRefType;
			DescriptionType _ItemDescription = ItemDescription;
			CoitemStatusType _Stat = Stat;
			InfobarType _Prefix = Prefix;
			InfobarType _PXrefDestination = PXrefDestination;
			ListYesNoType _CreateFlag = CreateFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitemxPISp";
				
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
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefDestination", _PXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PXrefDestination = _PXrefDestination;
				CreateFlag = _CreateFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PXrefDestination, CreateFlag, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
