//PROJECT NAME: CSIVendor
//CLASS NAME: GenerateLCVoucherCompStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateLCVoucherCompStatus
	{
		int GenerateLCVoucherCompStatusSp(ref string Infobar);
	}
	
	public class GenerateLCVoucherCompStatus : IGenerateLCVoucherCompStatus
	{
		readonly IApplicationDB appDB;
		
		public GenerateLCVoucherCompStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GenerateLCVoucherCompStatusSp(ref string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateLCVoucherCompStatusSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
