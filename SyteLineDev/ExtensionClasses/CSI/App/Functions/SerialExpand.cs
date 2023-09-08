//PROJECT NAME: Data
//CLASS NAME: SerialExpand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SerialExpand : ISerialExpand
	{
		readonly IApplicationDB appDB;
		
		public SerialExpand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SerialExpandFn(
			string Site = null)
		{
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SerialExpand](@Site)";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
