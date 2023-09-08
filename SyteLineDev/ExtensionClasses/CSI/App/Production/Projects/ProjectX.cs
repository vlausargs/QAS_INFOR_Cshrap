//PROJECT NAME: Production
//CLASS NAME: ProjectX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjectX : IProjectX
	{
		readonly IApplicationDB appDB;
		
		public ProjectX(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PXrefDestination,
			int? CreateProj,
			int? CreateProjtask,
			string PromptMsg,
			string PromptButtons,
			string Infobar) ProjectXSp(
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Item,
			string PXrefDestination,
			int? CreateProj,
			int? CreateProjtask,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqLineType _RefLineSuf = RefLineSuf;
			CoReleaseType _RefRelease = RefRelease;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ItemType _Item = Item;
			InfobarType _PXrefDestination = PXrefDestination;
			ListYesNoType _CreateProj = CreateProj;
			ListYesNoType _CreateProjtask = CreateProjtask;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjectXSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefDestination", _PXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateProj", _CreateProj, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateProjtask", _CreateProjtask, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PXrefDestination = _PXrefDestination;
				CreateProj = _CreateProj;
				CreateProjtask = _CreateProjtask;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PXrefDestination, CreateProj, CreateProjtask, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
