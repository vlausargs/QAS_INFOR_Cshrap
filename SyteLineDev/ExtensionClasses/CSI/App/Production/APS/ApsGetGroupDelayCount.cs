//PROJECT NAME: Production
//CLASS NAME: ApsGetGroupDelayCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetGroupDelayCount : IApsGetGroupDelayCount
	{
		readonly IApplicationDB appDB;
		
		public ApsGetGroupDelayCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetGroupDelayCountFn(
			string Group,
			DateTime? StartDate,
			DateTime? EndDate)
		{
			ApsResgroupType _Group = Group;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetGroupDelayCount](@Group, @StartDate, @EndDate)";
				
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
