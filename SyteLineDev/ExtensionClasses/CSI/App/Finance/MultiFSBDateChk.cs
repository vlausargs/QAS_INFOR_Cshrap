//PROJECT NAME: Finance
//CLASS NAME: MultiFSBDateChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBDateChk
	{
		(int? ReturnCode, string Infobar,
		string PromptMsg,
		string PromptButtons) MultiFSBDateChkSp(string PeriodName = null,
		DateTime? PDate = null,
		string FieldLabel = null,
		string FunctionLabel = null,
		string Infobar = null,
		string PromptMsg = null,
		string PromptButtons = null);
	}
	
	public class MultiFSBDateChk : IMultiFSBDateChk
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBDateChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string PromptMsg,
		string PromptButtons) MultiFSBDateChkSp(string PeriodName = null,
		DateTime? PDate = null,
		string FieldLabel = null,
		string FunctionLabel = null,
		string Infobar = null,
		string PromptMsg = null,
		string PromptButtons = null)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			DateType _PDate = PDate;
			FormNameOrCaptionType _FieldLabel = FieldLabel;
			FormNameOrCaptionType _FunctionLabel = FunctionLabel;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBDateChkSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FieldLabel", _FieldLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FunctionLabel", _FunctionLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
