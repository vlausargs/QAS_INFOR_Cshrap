//PROJECT NAME: Production
//CLASS NAME: ApsGetPlanningStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetPlanningStartDate : IApsGetPlanningStartDate
	{
		readonly IApplicationDB appDB;
		
		public ApsGetPlanningStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? ApsGetPlanningStartDateFn(
			int? AltNum)
		{
			ApsAltNoType _AltNum = AltNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetPlanningStartDate](@AltNum)";
				
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
