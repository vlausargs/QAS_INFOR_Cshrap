//PROJECT NAME: Data
//CLASS NAME: IsExternalAddonAvailable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsExternalAddonAvailable : IIsExternalAddonAvailable
	{
		readonly IApplicationDB appDB;
		
		public IsExternalAddonAvailable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsExternalAddonAvailableFn(
			string ModuleName)
		{
			LicenseModuleNameType _ModuleName = ModuleName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsExternalAddonAvailable](@ModuleName)";
				
				appDB.AddCommandParameter(cmd, "ModuleName", _ModuleName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
