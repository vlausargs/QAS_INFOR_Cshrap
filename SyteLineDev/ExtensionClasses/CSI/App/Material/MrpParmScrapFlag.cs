//PROJECT NAME: Material
//CLASS NAME: MrpParmScrapFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmScrapFlag : IMrpParmScrapFlag
	{
		readonly IApplicationDB appDB;
		
		public MrpParmScrapFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmScrapFlagFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpParmScrapFlag]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
