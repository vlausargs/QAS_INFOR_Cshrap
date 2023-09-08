//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedCanAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSchedCanAdd : ISSSFSSchedCanAdd
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedCanAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSchedCanAddFn(
			string PartnerId)
		{
			FSPartnerType _PartnerId = PartnerId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSchedCanAdd](@PartnerId)";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
