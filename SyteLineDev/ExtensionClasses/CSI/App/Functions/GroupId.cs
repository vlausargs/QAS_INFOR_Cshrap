//PROJECT NAME: Data
//CLASS NAME: GroupId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GroupId : IGroupId
	{
		readonly IApplicationDB appDB;
		
		public GroupId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GroupIdSp(
			string Groupname)
		{
			GroupnameType _Groupname = Groupname;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GroupIdSp](@Groupname)";
				
				appDB.AddCommandParameter(cmd, "Groupname", _Groupname, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
