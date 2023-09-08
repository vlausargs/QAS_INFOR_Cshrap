//PROJECT NAME: CSIAPS
//CLASS NAME: Cal000MrpDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICal000MrpDates
	{
		int Cal000MrpDatesSp(ApsAltNoType AltNo,
		                     ref DateType PStartDate,
		                     ref DateType PEndDate);
	}
	
	public class Cal000MrpDates : ICal000MrpDates
	{
		readonly IApplicationDB appDB;
		
		public Cal000MrpDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Cal000MrpDatesSp(ApsAltNoType AltNo,
		                            ref DateType PStartDate,
		                            ref DateType PEndDate)
		{
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Cal000MrpDatesSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", PStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndDate", PEndDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
