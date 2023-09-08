//PROJECT NAME: Logistics
//CLASS NAME: VoucherValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherValid : IVoucherValid
	{
		readonly IApplicationDB appDB;
		
		
		public VoucherValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VoucherValidSp(int? Voucher,
		string VendNum,
		string Infobar)
		{
			VoucherType _Voucher = Voucher;
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherValidSp";
				
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
