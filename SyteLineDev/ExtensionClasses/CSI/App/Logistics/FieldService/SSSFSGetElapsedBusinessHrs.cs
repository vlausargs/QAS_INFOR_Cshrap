//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetElapsedBusinessHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetElapsedBusinessHrs : ISSSFSGetElapsedBusinessHrs
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetElapsedBusinessHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? SSSFSGetElapsedBusinessHrsFn(
			DateTime? iOpenDate,
			DateTime? iCloseDate)
		{
			DateTimeType _iOpenDate = iOpenDate;
			DateTimeType _iCloseDate = iCloseDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetElapsedBusinessHrs](@iOpenDate, @iCloseDate)";
				
				appDB.AddCommandParameter(cmd, "iOpenDate", _iOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCloseDate", _iCloseDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
