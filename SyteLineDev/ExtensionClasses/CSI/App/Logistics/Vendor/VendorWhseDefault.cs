//PROJECT NAME: CSIVendor
//CLASS NAME: VendorWhseDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IVendorWhseDefault
	{
		int VendorWhseDefaultSp(string PVendNum,
		                        ref string PWhse,
		                        ref string Infobar);
	}
	
	public class VendorWhseDefault : IVendorWhseDefault
	{
		readonly IApplicationDB appDB;
		
		public VendorWhseDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int VendorWhseDefaultSp(string PVendNum,
		                               ref string PWhse,
		                               ref string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			WhseType _PWhse = PWhse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorWhseDefaultSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PWhse = _PWhse;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
