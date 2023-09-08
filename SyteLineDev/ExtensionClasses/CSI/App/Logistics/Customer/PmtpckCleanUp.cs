//PROJECT NAME: Logistics
//CLASS NAME: PmtpckCleanUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckCleanUp : IPmtpckCleanUp
	{
		readonly IApplicationDB appDB;
		
		
		public PmtpckCleanUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmtpckCleanUpSp(Guid? PProcessId)
		{
			RowPointerType _PProcessId = PProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckCleanUpSp";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
