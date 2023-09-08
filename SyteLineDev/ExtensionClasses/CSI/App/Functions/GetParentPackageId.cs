//PROJECT NAME: Data
//CLASS NAME: GetParentPackageId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetParentPackageId : IGetParentPackageId
	{
		readonly IApplicationDB appDB;
		
		public GetParentPackageId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetParentPackageIdFn(
			decimal? ShipmentId,
			int? PackageID)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			PackageIDType _PackageID = PackageID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetParentPackageId](@ShipmentId, @PackageID)";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageID", _PackageID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
