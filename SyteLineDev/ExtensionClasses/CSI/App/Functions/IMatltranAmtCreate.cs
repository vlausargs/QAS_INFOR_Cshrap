//PROJECT NAME: Data
//CLASS NAME: IMatltranAmtCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMatltranAmtCreate
	{
		(int? ReturnCode,
			int? TransSeq,
			Guid? RowPointer) MatltranAmtCreateSp(
			Guid? BufferJournal = null,
			int? Adj = 0,
			decimal? TransNum = null,
			int? TransSeq = null,
			decimal? Amt = 0,
			string Acct = null,
			string AcctUnit1 = null,
			string AcctUnit2 = null,
			string AcctUnit3 = null,
			string AcctUnit4 = null,
			decimal? MatlAmt = 0,
			string MatlAcct = null,
			string MatlAcctUnit1 = null,
			string MatlAcctUnit2 = null,
			string MatlAcctUnit3 = null,
			string MatlAcctUnit4 = null,
			decimal? LbrAmt = 0,
			string LbrAcct = null,
			string LbrAcctUnit1 = null,
			string LbrAcctUnit2 = null,
			string LbrAcctUnit3 = null,
			string LbrAcctUnit4 = null,
			decimal? FovhdAmt = 0,
			string FovhdAcct = null,
			string FovhdAcctUnit1 = null,
			string FovhdAcctUnit2 = null,
			string FovhdAcctUnit3 = null,
			string FovhdAcctUnit4 = null,
			decimal? VovhdAmt = 0,
			string VovhdAcct = null,
			string VovhdAcctUnit1 = null,
			string VovhdAcctUnit2 = null,
			string VovhdAcctUnit3 = null,
			string VovhdAcctUnit4 = null,
			decimal? OutAmt = 0,
			string OutAcct = null,
			string OutAcctUnit1 = null,
			string OutAcctUnit2 = null,
			string OutAcctUnit3 = null,
			string OutAcctUnit4 = null,
			Guid? RowPointer = null,
			int? IncludeInInventoryBalCalc = 0);
	}
}

