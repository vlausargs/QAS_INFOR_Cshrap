//PROJECT NAME: Logistics
//CLASS NAME: AppmtdGetNextSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtdGetNextSequence : IAppmtdGetNextSequence
	{
		readonly IApplicationDB appDB;
		
		public AppmtdGetNextSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PSeq,
			string Infobar) AppmtdGetNextSequenceSp(
			string PVendNum,
			string PBankCode,
			int? PCheckSeq,
			int? PSeq,
			string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			BankCodeType _PBankCode = PBankCode;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			VoucherType _PSeq = PSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtdGetNextSequenceSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSeq = _PSeq;
				Infobar = _Infobar;
				
				return (Severity, PSeq, Infobar);
			}
		}
	}
}
