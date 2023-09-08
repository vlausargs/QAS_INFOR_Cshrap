//PROJECT NAME: Data
//CLASS NAME: DisplayOurAddressSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayOurAddressSite : IDisplayOurAddressSite
	{
		readonly IApplicationDB appDB;
		
		public DisplayOurAddressSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayOurAddressSiteFn(
			string SiteRef)
		{
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayOurAddressSite](@SiteRef)";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
