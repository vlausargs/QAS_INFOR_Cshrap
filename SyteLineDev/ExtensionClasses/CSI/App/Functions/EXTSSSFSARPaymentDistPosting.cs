//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSARPaymentDistPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSARPaymentDistPosting : IEXTSSSFSARPaymentDistPosting
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSARPaymentDistPosting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTSSSFSARPaymentDistPostingSp(
			string ReApplyType,
			DateTime? TIssueDate,
			int? ArpmtCheckNum,
			string CustomerCustNum,
			string ArpmtdCoNum,
			decimal? ForeignAmtApplied,
			string DepositDebitAcct,
			string DepositDebitUnit1,
			string DepositDebitUnit2,
			string DepositDebitUnit3,
			string DepositDebitUnit4,
			string ChartAcct,
			string TUnit1,
			string TUnit2,
			string TUnit3,
			string TUnit4,
			DateTime? ArpmtRecptDate,
			string CrossSitePost,
			string ArpmtBankCode,
			string Infobar)
		{
			ArtranTypeType _ReApplyType = ReApplyType;
			DateType _TIssueDate = TIssueDate;
			ArCheckNumType _ArpmtCheckNum = ArpmtCheckNum;
			CustNumType _CustomerCustNum = CustomerCustNum;
			CoNumType _ArpmtdCoNum = ArpmtdCoNum;
			AmountType _ForeignAmtApplied = ForeignAmtApplied;
			AcctType _DepositDebitAcct = DepositDebitAcct;
			UnitCode1Type _DepositDebitUnit1 = DepositDebitUnit1;
			UnitCode2Type _DepositDebitUnit2 = DepositDebitUnit2;
			UnitCode3Type _DepositDebitUnit3 = DepositDebitUnit3;
			UnitCode4Type _DepositDebitUnit4 = DepositDebitUnit4;
			AcctType _ChartAcct = ChartAcct;
			UnitCode1Type _TUnit1 = TUnit1;
			UnitCode2Type _TUnit2 = TUnit2;
			UnitCode3Type _TUnit3 = TUnit3;
			UnitCode4Type _TUnit4 = TUnit4;
			DateType _ArpmtRecptDate = ArpmtRecptDate;
			SiteType _CrossSitePost = CrossSitePost;
			BankCodeType _ArpmtBankCode = ArpmtBankCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSARPaymentDistPostingSp";
				
				appDB.AddCommandParameter(cmd, "ReApplyType", _ReApplyType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIssueDate", _TIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCheckNum", _ArpmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerCustNum", _CustomerCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdCoNum", _ArpmtdCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForeignAmtApplied", _ForeignAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitAcct", _DepositDebitAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit1", _DepositDebitUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit2", _DepositDebitUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit3", _DepositDebitUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit4", _DepositDebitUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartAcct", _ChartAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit1", _TUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit2", _TUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit3", _TUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit4", _TUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRecptDate", _ArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CrossSitePost", _CrossSitePost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtBankCode", _ArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
