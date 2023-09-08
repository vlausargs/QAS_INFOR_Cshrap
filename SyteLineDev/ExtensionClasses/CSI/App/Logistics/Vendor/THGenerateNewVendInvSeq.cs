//PROJECT NAME: Logistics
//CLASS NAME: THGenerateNewVendInvSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ITHGenerateNewVendInvSeq
	{
		(int? ReturnCode, string Newvendinv, string Newwhtseq) THGenerateNewVendInvSeqSp(string VendorNum = null,
		                                                                                 int? voucher = null,
		                                                                                 DateTime? InvDate = null,
		                                                                                 string Newvendinv = null,
		                                                                                 string Newwhtseq = null,
		                                                                                 Guid? ThapptcdRp = null);
	}
	
	public class THGenerateNewVendInvSeq : ITHGenerateNewVendInvSeq
	{
		readonly IApplicationDB appDB;
		
		public THGenerateNewVendInvSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Newvendinv, string Newwhtseq) THGenerateNewVendInvSeqSp(string VendorNum = null,
		                                                                                        int? voucher = null,
		                                                                                        DateTime? InvDate = null,
		                                                                                        string Newvendinv = null,
		                                                                                        string Newwhtseq = null,
		                                                                                        Guid? ThapptcdRp = null)
		{
			VendNumType _VendorNum = VendorNum;
			IntType _voucher = voucher;
			DateTimeType _InvDate = InvDate;
			StringType _Newvendinv = Newvendinv;
			StringType _Newwhtseq = Newwhtseq;
			RowPointerType _ThapptcdRp = ThapptcdRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THGenerateNewVendInvSeqSp";
				
				appDB.AddCommandParameter(cmd, "VendorNum", _VendorNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "voucher", _voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Newvendinv", _Newvendinv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Newwhtseq", _Newwhtseq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ThapptcdRp", _ThapptcdRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Newvendinv = _Newvendinv;
				Newwhtseq = _Newwhtseq;
				
				return (Severity, Newvendinv, Newwhtseq);
			}
		}
	}
}
