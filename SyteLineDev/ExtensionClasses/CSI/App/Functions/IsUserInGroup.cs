//PROJECT NAME: Data
//CLASS NAME: IsUserInGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsUserInGroup : IIsUserInGroup
	{
		readonly IApplicationDB appDB;
		
		public IsUserInGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsUserInGroupFn(
			string Username,
			string GroupName)
		{
			UsernameType _Username = Username;
			GroupnameType _GroupName = GroupName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsUserInGroup](@Username, @GroupName)";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupName", _GroupName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
