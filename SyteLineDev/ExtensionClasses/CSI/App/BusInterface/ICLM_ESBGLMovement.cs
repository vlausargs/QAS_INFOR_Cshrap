//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBGLMovement.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBGLMovement
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBGLMovementSp(string GLNomAcctName,
		string ChartType,
		int? FiscalYear,
		int? Period,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		int? Actual,
		string ActionCode);
	}
}

