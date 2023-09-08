//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubCreateHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubCreateHdr
	{
		(int? ReturnCode,
			string InvNum,
			Guid? ArinvRowPointer,
			string Infobar) SSSFSSROInvSubCreateHdrSp(
			string Mode,
			string CustNum,
			int? CustSeq,
			string TaxCode1,
			string TaxCode2,
			string TermsCode,
			string SRONum,
			string InvCred,
			DateTime? InvDate,
			string ArAcct,
			string ArAcctUnit1,
			string ArAcctUnit2,
			string ArAcctUnit3,
			string ArAcctUnit4,
			string InvNum,
			Guid? ArinvRowPointer,
			string Infobar);
	}
}

