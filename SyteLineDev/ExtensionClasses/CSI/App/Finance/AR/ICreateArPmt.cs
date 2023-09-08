//PROJECT NAME: Finance
//CLASS NAME: ICreateArPmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface ICreateArPmt
	{
		(int? ReturnCode,
			string Infobar) CreateArPmtSp(
			string CustNum,
			int? CheckNum,
			DateTime? RecptDate,
			decimal? DomCheckAmt,
			string Ref,
			string Description,
			int? TransferCash,
			string Type,
			string BankCode,
			decimal? ExchRate,
			decimal? ForCheckAmt,
			DateTime? DueDate,
			int? NoteExistsflag,
			string InvNum,
			string Site,
			decimal? DomAmtApplied,
			decimal? DomDiscAmt,
			string DiscAcct,
			decimal? DomAllowAmt,
			string AllowAcct,
			string ApplyCustNum,
			decimal? ForAmtApplied,
			int? CreateArpmt,
			int? CreateArpmtd,
			string Infobar,
			string DiscAcctUnit1,
			string DiscAcctUnit2,
			string DiscAcctUnit3,
			string DiscAcctUnit4,
			decimal? ForDiscAmt,
			decimal? PayCheckAmt,
			decimal? PayExchRate,
			string CurrCode);
	}
}

