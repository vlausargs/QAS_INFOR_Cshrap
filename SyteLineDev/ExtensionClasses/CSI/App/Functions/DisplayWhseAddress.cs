//PROJECT NAME: Data
//CLASS NAME: DisplayWhseAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayWhseAddress : IDisplayWhseAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayWhseAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayWhseAddressSp(
			string Whse,
			string SiteRef)
		{
			WhseType _Whse = Whse;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayWhseAddressSp](@Whse, @SiteRef)";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
