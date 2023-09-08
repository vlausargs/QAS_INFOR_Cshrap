//PROJECT NAME: Production
//CLASS NAME: ApsAdjustOutsideOperations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsAdjustOutsideOperations : IApsAdjustOutsideOperations
	{
		readonly IApplicationDB appDB;
		
		public ApsAdjustOutsideOperations(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsAdjustOutsideOperationsSp(
			DateTime? StartDate,
			int? AltNo)
		{
			DateType _StartDate = StartDate;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsAdjustOutsideOperationsSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
