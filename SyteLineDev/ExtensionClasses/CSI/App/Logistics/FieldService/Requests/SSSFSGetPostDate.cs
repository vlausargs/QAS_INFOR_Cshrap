//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetPostDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetPostDate : ISSSFSGetPostDate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSGetPostDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? TransDate,
		DateTime? PostDate,
		string Prompt,
		string PromptButtons,
		string Infobar) SSSFSGetPostDateSp(DateTime? TransDate,
		DateTime? PostDate,
		int? Error,
		string Prompt,
		string PromptButtons,
		string Infobar)
		{
			DateType _TransDate = TransDate;
			DateType _PostDate = PostDate;
			IntType _Error = Error;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetPostDateSp";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Error", _Error, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransDate = _TransDate;
				PostDate = _PostDate;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, TransDate, PostDate, Prompt, PromptButtons, Infobar);
			}
		}
	}
}
