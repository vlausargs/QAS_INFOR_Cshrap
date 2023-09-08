//PROJECT NAME: Data
//CLASS NAME: ExpandLotKy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ExpandLotKy : IExpandLotKy
	{
		readonly IApplicationDB appDB;
		
		public ExpandLotKy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ExpandLotKyFn(
			string Key,
			string Site,
			string Prefix)
		{
			LotType _Key = Key;
			SiteType _Site = Site;
			LotPrefixType _Prefix = Prefix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ExpandLotKy](@Key, @Site, @Prefix)";
				
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
