//PROJECT NAME: CSIVendor
//CLASS NAME: GetNextVouchSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetNextVouchSeq
	{
		int GetNextVouchSeqSp(int? Voucher,
		                      string VendNum,
		                      ref int? VouchSeq);
	}
	
	public class GetNextVouchSeq : IGetNextVouchSeq
	{
		readonly IApplicationDB appDB;
		
		public GetNextVouchSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetNextVouchSeqSp(int? Voucher,
		                             string VendNum,
		                             ref int? VouchSeq)
		{
			VoucherType _Voucher = Voucher;
			VendNumType _VendNum = VendNum;
			VouchSeqType _VouchSeq = VouchSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextVouchSeqSp";
				
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VouchSeq", _VouchSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VouchSeq = _VouchSeq;
				
				return Severity;
			}
		}
	}
}
