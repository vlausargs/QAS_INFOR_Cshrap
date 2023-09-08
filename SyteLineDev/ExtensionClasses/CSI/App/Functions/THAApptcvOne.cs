//PROJECT NAME: Data
//CLASS NAME: THAApptcvOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApptcvOne : ITHAApptcvOne
	{
		readonly IApplicationDB appDB;
		
		public THAApptcvOne(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) THAApptcvOneSp(
			string AppmtVendNum,
			DateTime? AppmtCheckDate,
			int? AppmtCheckSeq,
			string AppmtPayType,
			int? AppmtCheckNum,
			string AppmtBankCode,
			decimal? AppmtDomCheckAmt,
			string AppmtRef,
			decimal? AppmtForCheckAmt,
			string Infobar)
		{
			VendNumType _AppmtVendNum = AppmtVendNum;
			DateType _AppmtCheckDate = AppmtCheckDate;
			ApCheckSeqType _AppmtCheckSeq = AppmtCheckSeq;
			AppmtPayTypeType _AppmtPayType = AppmtPayType;
			ApCheckNumType _AppmtCheckNum = AppmtCheckNum;
			BankCodeType _AppmtBankCode = AppmtBankCode;
			AmountType _AppmtDomCheckAmt = AppmtDomCheckAmt;
			ReferenceType _AppmtRef = AppmtRef;
			AmountType _AppmtForCheckAmt = AppmtForCheckAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAApptcvOneSp";
				
				appDB.AddCommandParameter(cmd, "AppmtVendNum", _AppmtVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtCheckDate", _AppmtCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtCheckSeq", _AppmtCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtPayType", _AppmtPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtCheckNum", _AppmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtBankCode", _AppmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtDomCheckAmt", _AppmtDomCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtRef", _AppmtRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtForCheckAmt", _AppmtForCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
