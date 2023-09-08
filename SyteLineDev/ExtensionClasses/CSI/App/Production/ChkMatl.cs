//PROJECT NAME: Production
//CLASS NAME: ChkMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ChkMatl : IChkMatl
	{
		readonly IApplicationDB appDB;
		
		
		public ChkMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string Prompt,
		string PromptButtons) ChkMatlSp(string Item,
		string ItmItem,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null)
		{
			ItemType _Item = Item;
			ItemType _ItmItem = ItmItem;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkMatlSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmItem", _ItmItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
