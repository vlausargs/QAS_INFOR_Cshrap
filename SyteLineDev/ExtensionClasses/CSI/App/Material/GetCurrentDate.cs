//PROJECT NAME: Material
//CLASS NAME: GetCurrentDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetCurrentDate
	{
		(int? ReturnCode, DateTime? CurrentDate) GetCurrentDateSp(DateTime? CurrentDate);
	}
	
	public class GetCurrentDate : IGetCurrentDate
	{
		readonly IApplicationDB appDB;
		
		public GetCurrentDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? CurrentDate) GetCurrentDateSp(DateTime? CurrentDate)
		{
			DateTimeType _CurrentDate = CurrentDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurrentDateSp";
				
				appDB.AddCommandParameter(cmd, "CurrentDate", _CurrentDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrentDate = _CurrentDate;
				
				return (Severity, CurrentDate);
			}
		}
	}
}
