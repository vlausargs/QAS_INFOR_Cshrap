//PROJECT NAME: Production
//CLASS NAME: MO_ValAlternateAsk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class MO_ValAlternateAsk : IMO_ValAlternateAsk
	{
		readonly IApplicationDB appDB;
		
		
		public MO_ValAlternateAsk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string AlternateDescription,
		int? JobSuffix,
		string PromptAddMsg,
		string PromptAddButtons,
		string Infobar,
		int? OperNum) MO_ValAlternateAskSp(string JobItem,
		string AlternateID,
		string AlternateDescription,
		int? JobSuffix,
		string PromptAddMsg,
		string PromptAddButtons,
		string Infobar,
		int? OperNum = null)
		{
			ItemType _JobItem = JobItem;
			MO_BOMAlternateType _AlternateID = AlternateID;
			DescriptionType _AlternateDescription = AlternateDescription;
			SuffixType _JobSuffix = JobSuffix;
			InfobarType _PromptAddMsg = PromptAddMsg;
			InfobarType _PromptAddButtons = PromptAddButtons;
			InfobarType _Infobar = Infobar;
			OperNumType _OperNum = OperNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ValAlternateAskSp";
				
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateDescription", _AlternateDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddMsg", _PromptAddMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddButtons", _PromptAddButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AlternateDescription = _AlternateDescription;
				JobSuffix = _JobSuffix;
				PromptAddMsg = _PromptAddMsg;
				PromptAddButtons = _PromptAddButtons;
				Infobar = _Infobar;
				OperNum = _OperNum;
				
				return (Severity, AlternateDescription, JobSuffix, PromptAddMsg, PromptAddButtons, Infobar, OperNum);
			}
		}
	}
}
