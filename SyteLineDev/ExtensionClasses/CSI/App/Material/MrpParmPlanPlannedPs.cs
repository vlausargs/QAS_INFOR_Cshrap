//PROJECT NAME: Material
//CLASS NAME: MrpParmPlanPlannedPs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmPlanPlannedPs : IMrpParmPlanPlannedPs
	{
		readonly IApplicationDB appDB;
		
		public MrpParmPlanPlannedPs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmPlanPlannedPsFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpParmPlanPlannedPs]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
