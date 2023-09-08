//PROJECT NAME: Data
//CLASS NAME: ExpandKyByTypeSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ExpandKyByTypeSite : IExpandKyByTypeSite
	{
		readonly IApplicationDB appDB;
		
		public ExpandKyByTypeSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ExpandKyByTypeSiteFn(
			string DataType,
			string Key,
			string Site)
		{
			StringType _DataType = DataType;
			AlphaKeyType _Key = Key;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ExpandKyByTypeSite](@DataType, @Key, @Site)";
				
				appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
