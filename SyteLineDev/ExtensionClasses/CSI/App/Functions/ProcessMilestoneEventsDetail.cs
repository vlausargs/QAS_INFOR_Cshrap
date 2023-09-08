//PROJECT NAME: Data
//CLASS NAME: ProcessMilestoneEventsDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProcessMilestoneEventsDetail : IProcessMilestoneEventsDetail
	{
		readonly IApplicationDB appDB;
		
		public ProcessMilestoneEventsDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProcessMilestoneEventsDetailSp(
			string PProjNum,
			string MsGroup,
			int? IsInvoicePosted = 0,
			string Infobar = null)
		{
			ProjNumType _PProjNum = PProjNum;
			ProjMilestoneGroupType _MsGroup = MsGroup;
			ListYesNoType _IsInvoicePosted = IsInvoicePosted;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessMilestoneEventsDetailSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsGroup", _MsGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsInvoicePosted", _IsInvoicePosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
