//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCreateHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCreateHdr
	{
		(int? ReturnCode,
			string InvNum,
			int? InvSeq,
			string SalesAcct,
			string SalesAcctUnit1,
			string SalesAcctUnit2,
			string SalesAcctUnit3,
			string SalesAcctUnit4,
			decimal? ExchRate,
			Guid? ArinvRowPointer,
			string Infobar) SSSFSConInvSubCreateHdrSp(
			string Contract,
			int? SetAllFromContract,
			DateTime? InvDate,
			string InvNum,
			int? InvSeq,
			string SalesAcct,
			string SalesAcctUnit1,
			string SalesAcctUnit2,
			string SalesAcctUnit3,
			string SalesAcctUnit4,
			decimal? ExchRate,
			Guid? ArinvRowPointer,
			string Infobar,
			string CustNum = null,
			int? CustSeq = null,
			string ServType = null,
			string BillFreq = null,
			string BillType = null,
			string ProductCode = null,
			string TermsCode = null,
			string TaxCode1 = null,
			string TaxCode2 = null,
			string Slsman = null,
			string InvCred = "I");
	}
}

