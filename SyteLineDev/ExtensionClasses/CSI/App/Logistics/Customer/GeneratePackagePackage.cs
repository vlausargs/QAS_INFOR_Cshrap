//PROJECT NAME: CSICustomer
//CLASS NAME: GeneratePackagePackage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGeneratePackagePackage
	{
		int GeneratePackagePackageSp(Guid? ProcessId,
		                             int? PackageId,
		                             ref string InfoBar);
	}
	
	public class GeneratePackagePackage : IGeneratePackagePackage
	{
		readonly IApplicationDB appDB;
		
		public GeneratePackagePackage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GeneratePackagePackageSp(Guid? ProcessId,
		                                    int? PackageId,
		                                    ref string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			PackageIDType _PackageId = PackageId;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePackagePackageSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageId", _PackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
