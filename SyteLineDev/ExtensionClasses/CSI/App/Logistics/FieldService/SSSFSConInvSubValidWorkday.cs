//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubValidWorkday.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubValidWorkday : ISSSFSConInvSubValidWorkday
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubValidWorkday(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubValidWorkdayFn(
			DateTime? WorkDay)
		{
			GenericDate _WorkDay = WorkDay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConInvSubValidWorkday](@WorkDay)";
				
				appDB.AddCommandParameter(cmd, "WorkDay", _WorkDay, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
