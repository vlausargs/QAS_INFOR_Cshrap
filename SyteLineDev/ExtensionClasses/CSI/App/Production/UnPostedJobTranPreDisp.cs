//PROJECT NAME: Production
//CLASS NAME: UnPostedJobTranPreDisp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class UnPostedJobTranPreDisp : IUnPostedJobTranPreDisp
	{
		readonly IApplicationDB appDB;
		
		
		public UnPostedJobTranPreDisp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? rpt_in_hrs,
		int? job_stockrm,
		string check_oper_seq) UnPostedJobTranPreDispSp(int? rpt_in_hrs,
		int? job_stockrm,
		string check_oper_seq)
		{
			ListHrsMinType _rpt_in_hrs = rpt_in_hrs;
			ListYesNoType _job_stockrm = job_stockrm;
			ListAlwaysPromptNeverType _check_oper_seq = check_oper_seq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UnPostedJobTranPreDispSp";
				
				appDB.AddCommandParameter(cmd, "rpt_in_hrs", _rpt_in_hrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "job_stockrm", _job_stockrm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "check_oper_seq", _check_oper_seq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rpt_in_hrs = _rpt_in_hrs;
				job_stockrm = _job_stockrm;
				check_oper_seq = _check_oper_seq;
				
				return (Severity, rpt_in_hrs, job_stockrm, check_oper_seq);
			}
		}
	}
}
