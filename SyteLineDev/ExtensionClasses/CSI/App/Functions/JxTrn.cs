//PROJECT NAME: Data
//CLASS NAME: JxTrn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JxTrn : IJxTrn
	{
		readonly IApplicationDB appDB;
		
		public JxTrn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PAsk,
			string PTrnNum,
			int? PTrnLine,
			decimal? POrderQty,
			string PCommand,
			string PromptMsg,
			string Buttons,
			string Infobar) JxTrnSp(
			int? PAsk,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PTrnNum,
			int? PTrnLine,
			decimal? POrderQty,
			string PCommand,
			string PromptMsg,
			string Buttons,
			string Infobar,
			string ExportType)
		{
			FlagNyType _PAsk = PAsk;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			QtyUnitType _POrderQty = POrderQty;
			DescriptionType _PCommand = PCommand;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Buttons = Buttons;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JxTrnSp";
				
				appDB.AddCommandParameter(cmd, "PAsk", _PAsk, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POrderQty", _POrderQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCommand", _PCommand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAsk = _PAsk;
				PTrnNum = _PTrnNum;
				PTrnLine = _PTrnLine;
				POrderQty = _POrderQty;
				PCommand = _PCommand;
				PromptMsg = _PromptMsg;
				Buttons = _Buttons;
				Infobar = _Infobar;
				
				return (Severity, PAsk, PTrnNum, PTrnLine, POrderQty, PCommand, PromptMsg, Buttons, Infobar);
			}
		}
	}
}
