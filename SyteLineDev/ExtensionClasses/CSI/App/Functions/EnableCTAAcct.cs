//PROJECT NAME: Data
//CLASS NAME: EnableCTAAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EnableCTAAcct : IEnableCTAAcct
	{
		readonly IApplicationDB appDB;
		
		public EnableCTAAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EnableCTAAcctFn(
			string Site)
		{
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EnableCTAAcct](@Site)";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
