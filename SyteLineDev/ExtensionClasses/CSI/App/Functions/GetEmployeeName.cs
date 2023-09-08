//PROJECT NAME: Data
//CLASS NAME: GetEmployeeName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEmployeeName : IGetEmployeeName
	{
		readonly IApplicationDB appDB;
		
		public GetEmployeeName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetEmployeeNameFn(
			string EmpNum)
		{
			EmpNumType _EmpNum = EmpNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetEmployeeName](@EmpNum)";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
