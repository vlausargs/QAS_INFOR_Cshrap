//PROJECT NAME: Data
//CLASS NAME: GetTopEmpSalaryDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTopEmpSalaryDate : IGetTopEmpSalaryDate
	{
		readonly IApplicationDB appDB;
		
		public GetTopEmpSalaryDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetTopEmpSalaryDateFn(
			string pEmployeeNumCustNum)
		{
			EmpNumType _pEmployeeNumCustNum = pEmployeeNumCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetTopEmpSalaryDate](@pEmployeeNumCustNum)";
				
				appDB.AddCommandParameter(cmd, "pEmployeeNumCustNum", _pEmployeeNumCustNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
