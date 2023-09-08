//PROJECT NAME: Production
//CLASS NAME: ApsGlobalPlanningMode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGlobalPlanningMode : IApsGlobalPlanningMode
	{
		readonly IApplicationDB appDB;
		
		public ApsGlobalPlanningMode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGlobalPlanningModeFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGlobalPlanningMode]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
