//PROJECT NAME: Logistics
//CLASS NAME: TmpApQuickPaymentsCleanUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TmpApQuickPaymentsCleanUp : ITmpApQuickPaymentsCleanUp
	{
		readonly IApplicationDB appDB;
		
		
		public TmpApQuickPaymentsCleanUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TmpApQuickPaymentsCleanUpSp(Guid? SessionId)
		{
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TmpApQuickPaymentsCleanUpSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
