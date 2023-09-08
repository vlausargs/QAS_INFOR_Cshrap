//PROJECT NAME: POS
//CLASS NAME: ISSSPOSAppl_Cr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSAppl_Cr
	{
		(int? ReturnCode,
			string Infobar) SSSPOSAppl_CrSp(
			string POSMCredInvNum,
			string CoNum,
			string ParmCurrCode,
			string Infobar,
			string POSNum);
	}
}

