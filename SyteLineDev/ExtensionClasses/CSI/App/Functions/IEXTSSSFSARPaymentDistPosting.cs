//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSARPaymentDistPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSARPaymentDistPosting
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

