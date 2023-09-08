//PROJECT NAME: Data
//CLASS NAME: GetPositionTitle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPositionTitle : IGetPositionTitle
	{
		readonly IApplicationDB appDB;
		
		public GetPositionTitle(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetPositionTitleFn(
			string EmpNum,
			DateTime? Jobdate)
		{
			EmpNumType _EmpNum = EmpNum;
			DateType _Jobdate = Jobdate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPositionTitle](@EmpNum, @Jobdate)";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Jobdate", _Jobdate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
