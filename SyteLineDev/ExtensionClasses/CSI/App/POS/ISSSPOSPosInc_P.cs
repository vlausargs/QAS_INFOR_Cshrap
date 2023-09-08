//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPosInc_P.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPosInc_P
	{
		(int? ReturnCode,
			string InvNum,
			string Infobar) SSSPOSPosInc_PSp(
			string CoNum,
			string InvCred,
			string PosNum,
			string Mode,
			decimal? UserID,
			string ParmCurrCode,
			Guid? SessionID,
			string POSMCredInvNum,
			string InvNum,
			string Infobar,
			int? PackNum);
	}
}

