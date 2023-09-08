//PROJECT NAME: Production
//CLASS NAME: GetAlternDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IGetAlternDates
	{
		(int? ReturnCode, DateTime? StartDate,
		DateTime? EndDate) GetAlternDatesSp(DateTime? StartDate,
		DateTime? EndDate);
	}
	
	public class GetAlternDates : IGetAlternDates
	{
		readonly IApplicationDB appDB;
		
		public GetAlternDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? StartDate,
		DateTime? EndDate) GetAlternDatesSp(DateTime? StartDate,
		DateTime? EndDate)
		{
			GenericDateType _StartDate = StartDate;
			GenericDateType _EndDate = EndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAlternDatesSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartDate = _StartDate;
				EndDate = _EndDate;
				
				return (Severity, StartDate, EndDate);
			}
		}
	}
}
