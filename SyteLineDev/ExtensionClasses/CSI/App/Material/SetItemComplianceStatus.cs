//PROJECT NAME: Material
//CLASS NAME: SetItemComplianceStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class SetItemComplianceStatus : ISetItemComplianceStatus
	{
		readonly IApplicationDB appDB;
		
		
		public SetItemComplianceStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SetItemComplianceStatusSp(int? ProcessAll = 0,
		string ComplianceProgramId = null,
		string Mode = "N",
		string Infobar = null,
		DateTime? EffectDate = null)
		{
			ListYesNoType _ProcessAll = ProcessAll;
			ComplianceProgramIdType _ComplianceProgramId = ComplianceProgramId;
			StringType _Mode = Mode;
			InfobarType _Infobar = Infobar;
			DateType _EffectDate = EffectDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetItemComplianceStatusSp";
				
				appDB.AddCommandParameter(cmd, "ProcessAll", _ProcessAll, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ComplianceProgramId", _ComplianceProgramId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
