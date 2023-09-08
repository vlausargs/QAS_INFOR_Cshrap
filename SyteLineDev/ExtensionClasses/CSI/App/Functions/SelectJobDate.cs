//PROJECT NAME: Data
//CLASS NAME: SelectJobDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SelectJobDate : ISelectJobDate
	{
		readonly IApplicationDB appDB;
		
		public SelectJobDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? SelectJobDateFn(
			DateTime? pEndDate,
			DateTime? pCompDate,
			int? pScheduled,
			int? pMrpParmDynLead,
			int? pUseSchedTimesInPlanning,
			string pApsMode)
		{
			DateType _pEndDate = pEndDate;
			DateType _pCompDate = pCompDate;
			ListYesNoType _pScheduled = pScheduled;
			ListYesNoType _pMrpParmDynLead = pMrpParmDynLead;
			ListYesNoType _pUseSchedTimesInPlanning = pUseSchedTimesInPlanning;
			ApsModeType _pApsMode = pApsMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SelectJobDate](@pEndDate, @pCompDate, @pScheduled, @pMrpParmDynLead, @pUseSchedTimesInPlanning, @pApsMode)";
				
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCompDate", _pCompDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pScheduled", _pScheduled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMrpParmDynLead", _pMrpParmDynLead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseSchedTimesInPlanning", _pUseSchedTimesInPlanning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pApsMode", _pApsMode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
