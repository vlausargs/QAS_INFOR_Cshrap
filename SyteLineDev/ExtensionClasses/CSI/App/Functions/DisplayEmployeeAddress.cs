//PROJECT NAME: Data
//CLASS NAME: DisplayEmployeeAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayEmployeeAddress : IDisplayEmployeeAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayEmployeeAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayEmployeeAddressSp(
			string EmpNum)
		{
			EmpNumType _EmpNum = EmpNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayEmployeeAddressSp](@EmpNum)";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
