//PROJECT NAME: CSIProjects
//CLASS NAME: GetAvgHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetAvgHrs
	{
		int GetAvgHrsSp(ref decimal? AvgHrs);
	}
	
	public class GetAvgHrs : IGetAvgHrs
	{
		readonly IApplicationDB appDB;
		
		public GetAvgHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAvgHrsSp(ref decimal? AvgHrs)
		{
			ScalDurHoursType _AvgHrs = AvgHrs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAvgHrsSp";
				
				appDB.AddCommandParameter(cmd, "AvgHrs", _AvgHrs, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AvgHrs = _AvgHrs;
				
				return Severity;
			}
		}
	}
}
