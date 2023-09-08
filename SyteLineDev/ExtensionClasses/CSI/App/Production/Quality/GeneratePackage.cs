//PROJECT NAME: CSIRSQCS
//CLASS NAME: GeneratePackage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Quality
{
	public interface IGeneratePackage
	{
		int GeneratePackageSp(Guid? ProcessId,
		                      decimal? QtyPerPackage,
		                      ref string InfoBar);
	}
	
	public class GeneratePackage : IGeneratePackage
	{
		readonly IApplicationDB appDB;
		
		public GeneratePackage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GeneratePackageSp(Guid? ProcessId,
		                             decimal? QtyPerPackage,
		                             ref string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			QtyUnitNoNegType _QtyPerPackage = QtyPerPackage;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePackageSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPerPackage", _QtyPerPackage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
