//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncPriorityDatesWorkDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSIncPriorityDatesWorkDay : ISSSFSIncPriorityDatesWorkDay
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncPriorityDatesWorkDay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSIncPriorityDatesWorkDayFn(
			DateTime? Date,
			int? WorkDay1,
			int? WorkDay2,
			int? WorkDay3,
			int? WorkDay4,
			int? WorkDay5,
			int? WorkDay6,
			int? WorkDay7,
			int? ServOnHolidays)
		{
			DateTimeType _Date = Date;
			ListYesNoType _WorkDay1 = WorkDay1;
			ListYesNoType _WorkDay2 = WorkDay2;
			ListYesNoType _WorkDay3 = WorkDay3;
			ListYesNoType _WorkDay4 = WorkDay4;
			ListYesNoType _WorkDay5 = WorkDay5;
			ListYesNoType _WorkDay6 = WorkDay6;
			ListYesNoType _WorkDay7 = WorkDay7;
			ListYesNoType _ServOnHolidays = ServOnHolidays;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSIncPriorityDatesWorkDay](@Date, @WorkDay1, @WorkDay2, @WorkDay3, @WorkDay4, @WorkDay5, @WorkDay6, @WorkDay7, @ServOnHolidays)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay1", _WorkDay1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay2", _WorkDay2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay3", _WorkDay3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay4", _WorkDay4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay5", _WorkDay5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay6", _WorkDay6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDay7", _WorkDay7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServOnHolidays", _ServOnHolidays, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
