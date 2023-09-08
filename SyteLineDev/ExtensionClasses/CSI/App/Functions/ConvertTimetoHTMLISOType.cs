//PROJECT NAME: Data
//CLASS NAME: ConvertTimetoHTMLISOType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertTimetoHTMLISOType : IConvertTimetoHTMLISOType
	{
		readonly IApplicationDB appDB;
		
		public ConvertTimetoHTMLISOType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertTimetoHTMLISOTypeFn(
			int? TimeYear,
			int? TimeMonth,
			decimal? TimeDay,
			decimal? TimeHour,
			decimal? TimeMin,
			decimal? TimeSec)
		{
			IntType _TimeYear = TimeYear;
			IntType _TimeMonth = TimeMonth;
			DecimalType _TimeDay = TimeDay;
			DecimalType _TimeHour = TimeHour;
			DecimalType _TimeMin = TimeMin;
			DecimalType _TimeSec = TimeSec;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertTimetoHTMLISOType](@TimeYear, @TimeMonth, @TimeDay, @TimeHour, @TimeMin, @TimeSec)";
				
				appDB.AddCommandParameter(cmd, "TimeYear", _TimeYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeMonth", _TimeMonth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeDay", _TimeDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeHour", _TimeHour, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeMin", _TimeMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeSec", _TimeSec, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
