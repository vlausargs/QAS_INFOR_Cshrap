//PROJECT NAME: Logistics
//CLASS NAME: IsUserInReprintGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsUserInReprintGroup : IIsUserInReprintGroup
	{
		IApplicationDB appDB;
		
		
		public IsUserInReprintGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? IsUserInReprintGroup) IsUserInReprintGroupSp(decimal? Userid,
		int? IsUserInReprintGroup)
		{
			TokenType _Userid = Userid;
			FlagNyType _IsUserInReprintGroup = IsUserInReprintGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsUserInReprintGroupSp";
				
				appDB.AddCommandParameter(cmd, "Userid", _Userid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsUserInReprintGroup", _IsUserInReprintGroup, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsUserInReprintGroup = _IsUserInReprintGroup;
				
				return (Severity, IsUserInReprintGroup);
			}
		}
	}
}
