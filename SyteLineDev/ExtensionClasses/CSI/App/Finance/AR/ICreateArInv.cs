//PROJECT NAME: Finance
//CLASS NAME: ICreateArInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface ICreateArInv
	{
		(int? ReturnCode,
			string Infobar) CreateArInvSp(
			string CustNum,
			string InvNum,
			string Type,
			string CoNum,
			DateTime? InvDate,
			DateTime? DueDate,
			decimal? Amount,
			decimal? MiscCharges,
			decimal? SalesTax,
			decimal? Freight,
			string _ref,
			string TermsCode,
			string Description,
			int? PostFromCo,
			decimal? ExchRate,
			decimal? SalesTax2,
			int? UseExchRate,
			string TaxCode1,
			string TaxCode2,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4,
			string DistAcct,
			string DistAcctUnit1,
			string DistAcctUnit2,
			string DistAcctUnit3,
			string DistAcctUnit4,
			int? FixedRate,
			int? Rma,
			string PayType,
			int? DraftPrintFlag,
			string DoNum,
			int? NoteExistsflag,
			string Infobar,
			int? ReturnedCheck,
			string DiscAcct,
			string DiscAcctUnit1,
			string DiscAcctUnit2,
			string DiscAcctUnit3,
			string DiscAcctUnit4,
			decimal? DiscAmt,
			decimal? ShipmentId);
	}
}

