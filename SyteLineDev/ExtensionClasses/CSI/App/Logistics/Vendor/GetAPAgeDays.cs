//PROJECT NAME: CSIVendor
//CLASS NAME: GetAPAgeDays.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAPAgeDays
	{
		int GetAPAgeDaysSP(ref short? AgeDays1,
		                   ref string AgeDesc1,
		                   ref short? AgeDays2,
		                   ref string AgeDesc2,
		                   ref short? AgeDays3,
		                   ref string AgeDesc3,
		                   ref short? AgeDays4,
		                   ref string AgeDesc4,
		                   ref short? AgeDays5,
		                   ref string AgeDesc5);
	}
	
	public class GetAPAgeDays : IGetAPAgeDays
	{
		readonly IApplicationDB appDB;
		
		public GetAPAgeDays(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAPAgeDaysSP(ref short? AgeDays1,
		                          ref string AgeDesc1,
		                          ref short? AgeDays2,
		                          ref string AgeDesc2,
		                          ref short? AgeDays3,
		                          ref string AgeDesc3,
		                          ref short? AgeDays4,
		                          ref string AgeDesc4,
		                          ref short? AgeDays5,
		                          ref string AgeDesc5)
		{
			AgeDaysType _AgeDays1 = AgeDays1;
			AgeDescType _AgeDesc1 = AgeDesc1;
			AgeDaysType _AgeDays2 = AgeDays2;
			AgeDescType _AgeDesc2 = AgeDesc2;
			AgeDaysType _AgeDays3 = AgeDays3;
			AgeDescType _AgeDesc3 = AgeDesc3;
			AgeDaysType _AgeDays4 = AgeDays4;
			AgeDescType _AgeDesc4 = AgeDesc4;
			AgeDaysType _AgeDays5 = AgeDays5;
			AgeDescType _AgeDesc5 = AgeDesc5;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAPAgeDaysSP";
				
				appDB.AddCommandParameter(cmd, "AgeDays1", _AgeDays1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDesc1", _AgeDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDays2", _AgeDays2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDesc2", _AgeDesc2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDays3", _AgeDays3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDesc3", _AgeDesc3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDays4", _AgeDays4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDesc4", _AgeDesc4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDays5", _AgeDays5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeDesc5", _AgeDesc5, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AgeDays1 = _AgeDays1;
				AgeDesc1 = _AgeDesc1;
				AgeDays2 = _AgeDays2;
				AgeDesc2 = _AgeDesc2;
				AgeDays3 = _AgeDays3;
				AgeDesc3 = _AgeDesc3;
				AgeDays4 = _AgeDays4;
				AgeDesc4 = _AgeDesc4;
				AgeDays5 = _AgeDays5;
				AgeDesc5 = _AgeDesc5;
				
				return Severity;
			}
		}
	}
}
