//PROJECT NAME: Finance
//CLASS NAME: GetNextStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetNextStartDate : IGetNextStartDate
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? NextStartDate) GetNextStartDateSp(DateTime? NextStartDate)
		{
			DateType _NextStartDate = NextStartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextStartDateSp";
				
				appDB.AddCommandParameter(cmd, "NextStartDate", _NextStartDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextStartDate = _NextStartDate;
				
				return (Severity, NextStartDate);
			}
		}
	}
}
