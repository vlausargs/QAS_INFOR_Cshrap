//PROJECT NAME: Data
//CLASS NAME: VerifyVoucherExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VerifyVoucherExist : IVerifyVoucherExist
	{
		readonly IApplicationDB appDB;
		
		public VerifyVoucherExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ValidVoucher) VerifyVoucherExistSp(
			string RVendNum,
			int? RVoucher,
			int? ValidVoucher)
		{
			VendNumType _RVendNum = RVendNum;
			VoucherType _RVoucher = RVoucher;
			FlagNyType _ValidVoucher = ValidVoucher;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyVoucherExistSp";
				
				appDB.AddCommandParameter(cmd, "RVendNum", _RVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RVoucher", _RVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ValidVoucher", _ValidVoucher, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ValidVoucher = _ValidVoucher;
				
				return (Severity, ValidVoucher);
			}
		}
	}
}
