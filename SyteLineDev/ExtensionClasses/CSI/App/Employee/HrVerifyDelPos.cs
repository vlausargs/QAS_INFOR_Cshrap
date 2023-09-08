//PROJECT NAME: Employee
//CLASS NAME: HrVerifyDelPos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class HrVerifyDelPos : IHrVerifyDelPos
	{
		readonly IApplicationDB appDB;
		
		
		public HrVerifyDelPos(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) HrVerifyDelPosSp(string JobId,
		int? JobDetail,
		string Infobar)
		{
			JobIdType _JobId = JobId;
			JobDetailType _JobDetail = JobDetail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HrVerifyDelPosSp";
				
				appDB.AddCommandParameter(cmd, "JobId", _JobId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDetail", _JobDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
