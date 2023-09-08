//PROJECT NAME: Logistics
//CLASS NAME: VendorVerifyVoucherNo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorVerifyVoucherNo : IVendorVerifyVoucherNo
	{
		readonly IApplicationDB appDB;
		
		
		public VendorVerifyVoucherNo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VendorVerifyVoucherNoSp(int? RVoucher,
		string Infobar)
		{
			VoucherType _RVoucher = RVoucher;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorVerifyVoucherNoSp";
				
				appDB.AddCommandParameter(cmd, "RVoucher", _RVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
