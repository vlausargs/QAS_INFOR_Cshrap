//PROJECT NAME: Material
//CLASS NAME: MrpParmPreqChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmPreqChk : IMrpParmPreqChk
	{
		readonly IApplicationDB appDB;
		
		public MrpParmPreqChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmPreqChkFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpParmPreqChk]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
