//PROJECT NAME: Logistics
//CLASS NAME: ClearSTypeTTVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ClearSTypeTTVouchers : IClearSTypeTTVouchers
	{
		readonly IApplicationDB appDB;
		
		
		public ClearSTypeTTVouchers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ClearSTypeTTVouchersSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClearSTypeTTVouchersSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
