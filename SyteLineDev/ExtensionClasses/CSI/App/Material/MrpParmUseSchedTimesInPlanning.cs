//PROJECT NAME: Material
//CLASS NAME: MrpParmUseSchedTimesInPlanning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmUseSchedTimesInPlanning : IMrpParmUseSchedTimesInPlanning
	{
		readonly IApplicationDB appDB;
		
		public MrpParmUseSchedTimesInPlanning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmUseSchedTimesInPlanningFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpParmUseSchedTimesInPlanning]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
