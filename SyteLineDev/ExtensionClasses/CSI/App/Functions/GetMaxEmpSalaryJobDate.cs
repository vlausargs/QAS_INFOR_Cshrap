//PROJECT NAME: Data
//CLASS NAME: GetMaxEmpSalaryJobDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetMaxEmpSalaryJobDate : IGetMaxEmpSalaryJobDate
	{
		readonly IApplicationDB appDB;
		
		public GetMaxEmpSalaryJobDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetMaxEmpSalaryJobDateFn(
			string pEmployeeNumCustNum)
		{
			EmpNumType _pEmployeeNumCustNum = pEmployeeNumCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetMaxEmpSalaryJobDate](@pEmployeeNumCustNum)";
				
				appDB.AddCommandParameter(cmd, "pEmployeeNumCustNum", _pEmployeeNumCustNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
