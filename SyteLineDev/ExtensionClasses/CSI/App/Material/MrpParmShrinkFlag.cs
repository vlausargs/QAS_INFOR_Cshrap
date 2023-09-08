//PROJECT NAME: Material
//CLASS NAME: MrpParmShrinkFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmShrinkFlag : IMrpParmShrinkFlag
	{
		readonly IApplicationDB appDB;
		
		public MrpParmShrinkFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmShrinkFlagFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpParmShrinkFlag]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
