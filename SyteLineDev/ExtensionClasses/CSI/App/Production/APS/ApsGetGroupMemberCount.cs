//PROJECT NAME: Production
//CLASS NAME: ApsGetGroupMemberCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetGroupMemberCount : IApsGetGroupMemberCount
	{
		readonly IApplicationDB appDB;
		
		public ApsGetGroupMemberCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetGroupMemberCountFn(
			string Group)
		{
			ApsResgroupType _Group = Group;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetGroupMemberCount](@Group)";
				
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
