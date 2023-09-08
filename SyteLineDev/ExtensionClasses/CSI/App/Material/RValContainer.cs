//PROJECT NAME: Material
//CLASS NAME: RValContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class RValContainer : IRValContainer
	{
		readonly IApplicationDB appDB;
		
		
		public RValContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ContainerNum,
		int? AddContainer,
		string PromptMsg,
		string PromptButtons,
		string Infobar) RValContainerSp(string ContainerNum,
		string Whse,
		string Loc,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? AddContainer,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			RefTypeIJKOTType _RefType = RefType;
			CoJobPrjType _RefNum = RefNum;
			CoLineSuffixProjTaskType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			ByteType _AddContainer = AddContainer;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RValContainerSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddContainer", _AddContainer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ContainerNum = _ContainerNum;
				AddContainer = _AddContainer;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, ContainerNum, AddContainer, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
