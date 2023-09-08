//PROJECT NAME: Data
//CLASS NAME: TH_SaveToVendSeqTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TH_SaveToVendSeqTable : ITH_SaveToVendSeqTable
	{
		readonly IApplicationDB appDB;
		
		public TH_SaveToVendSeqTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TH_SaveToVendSeqTableSp(
			string VendorNum = null,
			int? voucher = null,
			DateTime? InvDate = null,
			string vendinv = null,
			string whtseq = null,
			Guid? ThapptcdRp = null)
		{
			VendNumType _VendorNum = VendorNum;
			VoucherType _voucher = voucher;
			DateType _InvDate = InvDate;
			VendInvNumType _vendinv = vendinv;
			TH_WHTSequenceType _whtseq = whtseq;
			RowPointerType _ThapptcdRp = ThapptcdRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TH_SaveToVendSeqTableSp";
				
				appDB.AddCommandParameter(cmd, "VendorNum", _VendorNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "voucher", _voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vendinv", _vendinv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "whtseq", _whtseq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThapptcdRp", _ThapptcdRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
