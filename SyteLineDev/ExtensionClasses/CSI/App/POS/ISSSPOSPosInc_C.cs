//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPosInc_C.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPosInc_C
	{
		(int? ReturnCode,
			string InvNum,
			string Infobar) SSSPOSPosInc_CSp(
			string CoNum,
			string CustNum,
			string InvCred,
			DateTime? InvDate,
			string InvNum,
			string Infobar,
			int? PackNum = 0);
	}
}

