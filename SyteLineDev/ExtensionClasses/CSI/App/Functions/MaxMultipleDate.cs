//PROJECT NAME: Data
//CLASS NAME: MaxMultipleDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaxMultipleDate : IMaxMultipleDate
	{
		readonly IApplicationDB appDB;
		
		public MaxMultipleDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? MaxMultipleDateFn(
			DateTime? Date1,
			DateTime? Date2,
			DateTime? Date3,
			DateTime? Date4,
			DateTime? Date5,
			DateTime? Date6)
		{
			DateType _Date1 = Date1;
			DateType _Date2 = Date2;
			DateType _Date3 = Date3;
			DateType _Date4 = Date4;
			DateType _Date5 = Date5;
			DateType _Date6 = Date6;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaxMultipleDate](@Date1, @Date2, @Date3, @Date4, @Date5, @Date6)";
				
				appDB.AddCommandParameter(cmd, "Date1", _Date1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date2", _Date2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date3", _Date3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date4", _Date4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date5", _Date5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date6", _Date6, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
