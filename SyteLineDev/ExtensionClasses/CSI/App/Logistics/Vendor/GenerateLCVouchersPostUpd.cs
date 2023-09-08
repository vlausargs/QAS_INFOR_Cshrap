//PROJECT NAME: Logistics
//CLASS NAME: GenerateLCVouchersPostUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVouchersPostUpd : IGenerateLCVouchersPostUpd
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateLCVouchersPostUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GenerateLCVouchersPostUpdSp(Guid? ProcessId)
		{
			RowPointerType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateLCVouchersPostUpdSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
