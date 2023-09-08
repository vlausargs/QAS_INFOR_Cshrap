//PROJECT NAME: Logistics
//CLASS NAME: GetParmDuePeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetParmDuePeriod : IGetParmDuePeriod
	{
		readonly IApplicationDB appDB;
		
		
		public GetParmDuePeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? DuePeriod) GetParmDuePeriodSp(int? DuePeriod)
		{
			DuePeriodType _DuePeriod = DuePeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetParmDuePeriodSp";
				
				appDB.AddCommandParameter(cmd, "DuePeriod", _DuePeriod, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DuePeriod = _DuePeriod;
				
				return (Severity, DuePeriod);
			}
		}
	}
}
