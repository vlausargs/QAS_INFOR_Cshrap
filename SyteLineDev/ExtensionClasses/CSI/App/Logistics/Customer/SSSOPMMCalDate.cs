//PROJECT NAME: Logistics
//CLASS NAME: SSSOPMMCalDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSOPMMCalDate : ISSSOPMMCalDate
	{
		readonly IApplicationDB appDB;
		
		public SSSOPMMCalDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? TJobDate) SSSOPMMCalDateSp(
			int? LeadTime,
			DateTime? TJobDate)
		{
			LeadTimeType _LeadTime = LeadTime;
			DateType _TJobDate = TJobDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSOPMMCalDateSp";
				
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TJobDate", _TJobDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TJobDate = _TJobDate;
				
				return (Severity, TJobDate);
			}
		}
	}
}
