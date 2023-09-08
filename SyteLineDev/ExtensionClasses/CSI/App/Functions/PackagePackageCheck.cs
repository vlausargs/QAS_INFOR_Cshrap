//PROJECT NAME: Data
//CLASS NAME: PackagePackageCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PackagePackageCheck : IPackagePackageCheck
	{
		readonly IApplicationDB appDB;
		
		public PackagePackageCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? DuplicateFlag,
			string InfoBar) PackagePackageCheckSp(
			int? RefPackageid,
			int? NewPackageId,
			decimal? ShipmentId,
			int? DuplicateFlag,
			string InfoBar)
		{
			PackageIDType _RefPackageid = RefPackageid;
			PackageIDType _NewPackageId = NewPackageId;
			ShipmentIDType _ShipmentId = ShipmentId;
			IntType _DuplicateFlag = DuplicateFlag;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PackagePackageCheckSp";
				
				appDB.AddCommandParameter(cmd, "RefPackageid", _RefPackageid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewPackageId", _NewPackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DuplicateFlag", _DuplicateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DuplicateFlag = _DuplicateFlag;
				InfoBar = _InfoBar;
				
				return (Severity, DuplicateFlag, InfoBar);
			}
		}
	}
}
