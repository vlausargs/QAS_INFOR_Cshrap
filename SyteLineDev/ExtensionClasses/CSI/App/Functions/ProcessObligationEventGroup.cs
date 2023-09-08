//PROJECT NAME: Data
//CLASS NAME: ProcessObligationEventGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProcessObligationEventGroup : IProcessObligationEventGroup
	{
		readonly IApplicationDB appDB;
		
		public ProcessObligationEventGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProcessObligationEventGroupSp(
			string PProjNum,
			string CostClass,
			string MsType,
			string MsGroup,
			int? MsTask,
			int? IsInvoicePosted,
			string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			CostCodeClassType _CostClass = CostClass;
			ProjMilestoneTypeType _MsType = MsType;
			ProjMilestoneGroupType _MsGroup = MsGroup;
			TaskNumType _MsTask = MsTask;
			ListYesNoType _IsInvoicePosted = IsInvoicePosted;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessObligationEventGroupSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostClass", _CostClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsType", _MsType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsGroup", _MsGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsTask", _MsTask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsInvoicePosted", _IsInvoicePosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
