//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubGetNextValidWorkday.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubGetNextValidWorkday : ISSSFSConInvSubGetNextValidWorkday
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubGetNextValidWorkday(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? SSSFSConInvSubGetNextValidWorkdayFn(
			DateTime? WorkDay)
		{
			DateTimeType _WorkDay = WorkDay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConInvSubGetNextValidWorkday](@WorkDay)";
				
				appDB.AddCommandParameter(cmd, "WorkDay", _WorkDay, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
