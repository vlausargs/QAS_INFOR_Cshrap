//PROJECT NAME: Data
//CLASS NAME: GlbankChangeAPDraftStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GlbankChangeAPDraftStatus : IGlbankChangeAPDraftStatus
	{
		readonly IApplicationDB appDB;
		
		public GlbankChangeAPDraftStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GlbankChangeAPDraftStatusSp(
			string RefNum,
			string BankHdrBankCode,
			int? GlbankCheckNum,
			decimal? GlbankDomCheckAmt,
			decimal? GlbankCheckAmt,
			string Infobar,
			DateTime? CheckDate = null)
		{
			VendNumType _RefNum = RefNum;
			BankCodeType _BankHdrBankCode = BankHdrBankCode;
			GlCheckNumType _GlbankCheckNum = GlbankCheckNum;
			AmountType _GlbankDomCheckAmt = GlbankDomCheckAmt;
			AmountType _GlbankCheckAmt = GlbankCheckAmt;
			Infobar _Infobar = Infobar;
			DateType _CheckDate = CheckDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlbankChangeAPDraftStatusSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankHdrBankCode", _BankHdrBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GlbankCheckNum", _GlbankCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GlbankDomCheckAmt", _GlbankDomCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GlbankCheckAmt", _GlbankCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
