//PROJECT NAME: Logistics
//CLASS NAME: VendorGetVoucherAdjDistTtl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorGetVoucherAdjDistTtl : IVendorGetVoucherAdjDistTtl
	{
		readonly IApplicationDB appDB;
		
		
		public VendorGetVoucherAdjDistTtl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TDistTotal,
		string Infobar) VendorGetVoucherAdjDistTtlSp(string TVendNum,
		int? TVoucher,
		decimal? TDistTotal,
		string Infobar)
		{
			VendNumType _TVendNum = TVendNum;
			VoucherType _TVoucher = TVoucher;
			AmountType _TDistTotal = TDistTotal;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorGetVoucherAdjDistTtlSp";
				
				appDB.AddCommandParameter(cmd, "TVendNum", _TVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TVoucher", _TVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDistTotal", _TDistTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TDistTotal = _TDistTotal;
				Infobar = _Infobar;
				
				return (Severity, TDistTotal, Infobar);
			}
		}
	}
}
