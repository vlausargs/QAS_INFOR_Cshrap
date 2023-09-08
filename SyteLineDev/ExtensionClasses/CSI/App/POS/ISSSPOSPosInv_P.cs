//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPosInv_P.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPosInv_P
	{
		(int? ReturnCode,
			string InvNum,
			string Infobar) SSSPOSPosInv_PSp(
			string SRONum,
			int? SROLine,
			int? SROOper,
			string InvCred,
			string POSNum,
			string Mode,
			decimal? UserID,
			string ParmCurrCode,
			Guid? SessionID,
			string POSMCredInvNum,
			string InvNum,
			string Infobar);
	}
}

