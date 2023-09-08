//PROJECT NAME: Employee
//CLASS NAME: EmpReviewDateSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class EmpReviewDateSet : IEmpReviewDateSet
	{
		readonly IApplicationDB appDB;
		
		
		public EmpReviewDateSet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EmpReviewDateSetSp(string EmpNum,
		DateTime? EmpReviewDate)
		{
			EmpNumType _EmpNum = EmpNum;
			DateType _EmpReviewDate = EmpReviewDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EmpReviewDateSetSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpReviewDate", _EmpReviewDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
