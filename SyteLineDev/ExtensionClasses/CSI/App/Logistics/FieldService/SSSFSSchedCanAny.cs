//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedCanAny.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSchedCanAny : ISSSFSSchedCanAny
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedCanAny(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSchedCanAnyFn(
			string Permission,
			string PartnerId)
		{
			UnusedCharType _Permission = Permission;
			FSPartnerType _PartnerId = PartnerId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSchedCanAny](@Permission, @PartnerId)";
				
				appDB.AddCommandParameter(cmd, "Permission", _Permission, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
