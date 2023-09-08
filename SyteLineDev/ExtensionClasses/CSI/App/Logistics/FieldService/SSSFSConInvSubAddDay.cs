//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubAddDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubAddDay : ISSSFSConInvSubAddDay
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubAddDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? SSSFSConInvSubAddDayFn(
			DateTime? WorkDay,
			int? Days)
		{
			DateType _WorkDay = WorkDay;
			IntType _Days = Days;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConInvSubAddDay](@WorkDay, @Days)";
				
				appDB.AddCommandParameter(cmd, "WorkDay", _WorkDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Days", _Days, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
