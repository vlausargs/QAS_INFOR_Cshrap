//PROJECT NAME: Production
//CLASS NAME: ProcessMilestoneEvents.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProcessMilestoneEvents : IProcessMilestoneEvents
	{
		readonly IApplicationDB appDB;
		
		
		public ProcessMilestoneEvents(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProcessMilestoneEventsSp(string PProjNum,
		int? IsInvoicePosted = 0,
		int? ChkProjMSOnOblig = 0,
		string Infobar = null)
		{
			ProjNumType _PProjNum = PProjNum;
			ListYesNoType _IsInvoicePosted = IsInvoicePosted;
			ListYesNoType _ChkProjMSOnOblig = ChkProjMSOnOblig;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessMilestoneEventsSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsInvoicePosted", _IsInvoicePosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChkProjMSOnOblig", _ChkProjMSOnOblig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
