//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetPartnerHoursPerDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetPartnerHoursPerDay : ISSSFSGetPartnerHoursPerDay
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetPartnerHoursPerDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSGetPartnerHoursPerDayFn(
			string PartnerId,
			int? DayOfTheWeek)
		{
			FSPartnerType _PartnerId = PartnerId;
			IntType _DayOfTheWeek = DayOfTheWeek;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetPartnerHoursPerDay](@PartnerId, @DayOfTheWeek)";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DayOfTheWeek", _DayOfTheWeek, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
