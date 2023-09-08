//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetAmtsApplied.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetAmtsApplied : IAppmtGetAmtsApplied
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtGetAmtsApplied(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PForAmt,
		decimal? PDomAmt,
		string Infobar) AppmtGetAmtsAppliedSp(string PBankCode,
		string PVendNum,
		int? PCheckSeq,
		decimal? PForAmt,
		decimal? PDomAmt,
		string Infobar)
		{
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PVendNum = PVendNum;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			AmountType _PForAmt = PForAmt;
			AmountType _PDomAmt = PDomAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtGetAmtsAppliedSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmt", _PForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomAmt", _PDomAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PForAmt = _PForAmt;
				PDomAmt = _PDomAmt;
				Infobar = _Infobar;
				
				return (Severity, PForAmt, PDomAmt, Infobar);
			}
		}
	}
}
