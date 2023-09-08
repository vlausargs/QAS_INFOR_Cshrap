//PROJECT NAME: Reporting
//CLASS NAME: ISSSVTXPostRegister.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSVTXPostRegister
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSVTXPostRegisterSp(string FormCaption,
		int? BGTaskID,
		DateTime? StartingInvDate,
		DateTime? EndingInvDate,
		int? StartINV_dateOffSET = null,
		int? ENDINV_dateOffSET = null,
		string pSite = null);
	}
}

