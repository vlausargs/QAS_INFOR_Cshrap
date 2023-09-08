//PROJECT NAME: Production
//CLASS NAME: ApsGetPlannerDatabaseSize.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetPlannerDatabaseSize : IApsGetPlannerDatabaseSize
	{
		readonly IApplicationDB appDB;
		
		public ApsGetPlannerDatabaseSize(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PDBSize) ApsGetPlannerDatabaseSizeSp(
			int? AltNo = 0,
			int? PDBSize = null)
		{
			ShortType _AltNo = AltNo;
			IntType _PDBSize = PDBSize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetPlannerDatabaseSizeSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDBSize", _PDBSize, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDBSize = _PDBSize;
				
				return (Severity, PDBSize);
			}
		}
	}
}
