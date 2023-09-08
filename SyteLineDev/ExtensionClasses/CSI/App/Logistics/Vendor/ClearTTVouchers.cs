//PROJECT NAME: CSIVendor
//CLASS NAME: ClearTTVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IClearTTVouchers
	{
		int ClearTTVouchersSp();
	}
	
	public class ClearTTVouchers : IClearTTVouchers
	{
		readonly IApplicationDB appDB;
		
		public ClearTTVouchers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ClearTTVouchersSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClearTTVouchersSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
