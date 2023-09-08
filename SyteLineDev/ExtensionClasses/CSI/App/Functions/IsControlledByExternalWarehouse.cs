//PROJECT NAME: Data
//CLASS NAME: IsControlledByExternalWarehouse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsControlledByExternalWarehouse : IIsControlledByExternalWarehouse
	{
		readonly IApplicationDB appDB;
		
		public IsControlledByExternalWarehouse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsControlledByExternalWarehouseFn(
			string PWhse,
			string PSite)
		{
			WhseType _PWhse = PWhse;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsControlledByExternalWarehouse](@PWhse, @PSite)";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
