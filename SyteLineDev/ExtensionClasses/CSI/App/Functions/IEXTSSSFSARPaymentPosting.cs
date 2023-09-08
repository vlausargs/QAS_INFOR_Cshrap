//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSARPaymentPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSARPaymentPosting
	{
		(int? ReturnCode,
			int? SkipDist,
			string Infobar) EXTSSSFSARPaymentPostingSp(
			string CorpSite,
			string ReApplyType,
			string ReApplyBankCode,
			decimal? ReApplyDisc,
			decimal? WireExchangeRate,
			DateTime? TIssueDate,
			int? TInvSeq,
			string CorpSiteCurrCode,
			string CorpSiteName,
			Guid? ArpmtRowPointer,
			string ArpmtCustNum,
			string ArpmtBankCode,
			string ArpmtType,
			string ArpmtCreditMemoNum,
			int? ArpmtCheckNum,
			DateTime? ArpmtRecptDate,
			DateTime? ArpmtDueDate,
			string ArpmtRef,
			int? ArpmtNoteExistsFlag,
			string ArpmtDescription,
			int? ArpmtTransferCash,
			Guid? ArpmtdRowPointer,
			string TAcct,
			string TUnit1,
			string TUnit2,
			string TUnit3,
			string TUnit4,
			int? SkipDist,
			string Infobar,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null);
	}
}

