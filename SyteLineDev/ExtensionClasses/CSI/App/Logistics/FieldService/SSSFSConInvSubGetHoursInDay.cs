//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubGetHoursInDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubGetHoursInDay : ISSSFSConInvSubGetHoursInDay
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubGetHoursInDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSConInvSubGetHoursInDayFn(
			DateTime? WorkDay)
		{
			GenericDate _WorkDay = WorkDay;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSConInvSubGetHoursInDay](@WorkDay)";
				
				appDB.AddCommandParameter(cmd, "WorkDay", _WorkDay, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
