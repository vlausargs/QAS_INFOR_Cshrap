//PROJECT NAME: Admin
//CLASS NAME: UserFormInGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class UserFormInGroup : IUserFormInGroup
	{
		IApplicationDB appDB;
		
		
		public UserFormInGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UserFormInGroupSp(string GroupName,
		decimal? UserId,
		string Infobar)
		{
			GroupnameType _GroupName = GroupName;
			TokenType _UserId = UserId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UserFormInGroupSp";
				
				appDB.AddCommandParameter(cmd, "GroupName", _GroupName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
