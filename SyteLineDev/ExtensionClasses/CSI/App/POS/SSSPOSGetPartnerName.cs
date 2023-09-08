//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetPartnerName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSGetPartnerName : ISSSPOSGetPartnerName
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSGetPartnerName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSPOSGetPartnerNameFn(
			string PartnerId,
			string UserName)
		{
			FSPartnerType _PartnerId = PartnerId;
			NameType _UserName = UserName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSPOSGetPartnerName](@PartnerId, @UserName)";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
