//PROJECT NAME: Logistics
//CLASS NAME: PmtpckPostUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckPostUpd : IPmtpckPostUpd
	{
		readonly IApplicationDB appDB;
		
		
		public PmtpckPostUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmtpckPostUpdSp(Guid? PProcessId)
		{
			RowPointerType _PProcessId = PProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckPostUpdSp";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
