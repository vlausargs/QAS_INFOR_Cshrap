//PROJECT NAME: Production
//CLASS NAME: ApsMemoryAndDiskEstimate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMemoryAndDiskEstimate : IApsMemoryAndDiskEstimate
	{
		readonly IApplicationDB appDB;
		
		public ApsMemoryAndDiskEstimate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PMemoryUse,
			int? PDiskUse) ApsMemoryAndDiskEstimateSp(
			int? PAltNo,
			int? PMemoryUse,
			int? PDiskUse)
		{
			ApsAltNoType _PAltNo = PAltNo;
			ApsMemoryType _PMemoryUse = PMemoryUse;
			ApsDiskSpaceType _PDiskUse = PDiskUse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMemoryAndDiskEstimateSp";
				
				appDB.AddCommandParameter(cmd, "PAltNo", _PAltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMemoryUse", _PMemoryUse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDiskUse", _PDiskUse, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PMemoryUse = _PMemoryUse;
				PDiskUse = _PDiskUse;
				
				return (Severity, PMemoryUse, PDiskUse);
			}
		}
	}
}
