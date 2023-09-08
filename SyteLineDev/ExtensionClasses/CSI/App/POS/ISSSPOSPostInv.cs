//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPostInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPostInv
	{
		(int? ReturnCode,
			string Infobar) SSSPOSPostInvSp(
			string InvNum,
			int? InvSeq,
			string InvCred,
			string CoNum,
			string POSNum,
			string CustNum,
			decimal? UserID,
			string ParmCurrCode,
			Guid? SessionID,
			string POSMCredInvNum,
			string Infobar);
	}
}

