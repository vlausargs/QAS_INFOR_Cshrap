//PROJECT NAME: Finance
//CLASS NAME: IARGetCustInvARAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARGetCustInvARAcct
	{
		(int? ReturnCode,
			string PArAcct,
			string PArAcctUnit1,
			string PArAcctUnit2,
			string PArAcctUnit3,
			string PArAcctUnit4,
			string Infobar) ARGetCustInvARAcctSp(
			string PCustNum,
			int? PCustSeq = 0,
			string PInvNum = null,
			int? PInvSeq = 0,
			string PArAcct = null,
			string PArAcctUnit1 = null,
			string PArAcctUnit2 = null,
			string PArAcctUnit3 = null,
			string PArAcctUnit4 = null,
			string Infobar = null);
	}
}

