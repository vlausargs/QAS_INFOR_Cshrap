//PROJECT NAME: Material
//CLASS NAME: MrpParmDynLead.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpParmDynLead : IMrpParmDynLead
	{
		readonly IApplicationDB appDB;
		
		public MrpParmDynLead(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MrpParmDynLeadFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpParmDynLead]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
