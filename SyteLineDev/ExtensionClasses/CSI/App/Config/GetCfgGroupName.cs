//PROJECT NAME: Config
//CLASS NAME: GetCfgGroupName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class GetCfgGroupName : IGetCfgGroupName
	{
		readonly IApplicationDB appDB;
		
		
		public GetCfgGroupName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string GroupName,
		string Infobar) GetCfgGroupNameSp(string UserName,
		string GroupName,
		string Infobar)
		{
			UsernameType _UserName = UserName;
			GroupnameType _GroupName = GroupName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCfgGroupNameSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupName", _GroupName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GroupName = _GroupName;
				Infobar = _Infobar;
				
				return (Severity, GroupName, Infobar);
			}
		}
	}
}
