//PROJECT NAME: CSIVendor
//CLASS NAME: CheckVendorExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckVendorExists
	{
		int CheckVendorExistsSp(string VendNum,
		                        ref string Infobar);
	}
	
	public class CheckVendorExists : ICheckVendorExists
	{
		readonly IApplicationDB appDB;
		
		public CheckVendorExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckVendorExistsSp(string VendNum,
		                               ref string Infobar)
		{
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckVendorExistsSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
