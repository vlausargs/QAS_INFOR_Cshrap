//PROJECT NAME: Logistics
//CLASS NAME: VoucherAllValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherAllValid : IVoucherAllValid
	{
		readonly IApplicationDB appDB;
		
		
		public VoucherAllValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Voucher,
		string Infobar) VoucherAllValidSp(int? Voucher,
		string VendNum,
		int? VouchSeq,
		string Type,
		string Infobar)
		{
			VoucherType _Voucher = Voucher;
			VendNumType _VendNum = VendNum;
			VouchSeqType _VouchSeq = VouchSeq;
			AptrxpTypeType _Type = Type;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherAllValidSp";
				
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VouchSeq", _VouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Voucher = _Voucher;
				Infobar = _Infobar;
				
				return (Severity, Voucher, Infobar);
			}
		}
	}
}
