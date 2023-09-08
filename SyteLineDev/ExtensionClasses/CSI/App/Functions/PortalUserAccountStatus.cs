//PROJECT NAME: Data
//CLASS NAME: PortalUserAccountStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalUserAccountStatus : IPortalUserAccountStatus
	{
		readonly IApplicationDB appDB;
		
		public PortalUserAccountStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PortalUserAccountStatusFn(
			string Username,
			string Portal)
		{
			UsernameType _Username = Username;
			StringType _Portal = Portal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PortalUserAccountStatus](@Username, @Portal)";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Portal", _Portal, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
