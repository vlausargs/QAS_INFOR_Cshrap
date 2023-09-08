//PROJECT NAME: Data
//CLASS NAME: IGainLoss.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLoss
	{
		(int? ReturnCode,
			string rInfobar) GainLossSp(
			int? pRelGl,
			int? pPostTrx,
			string pSCurrCode,
			string pECurrCode,
			int? pRcvAcctType,
			int? pPayAcctType,
			int? pVouchPayAcctType,
			DateTime? pTTransDate,
			string pInvAdjAcct = null,
			string pInvAdjAcctUnit1 = null,
			string pInvAdjAcctUnit2 = null,
			string pInvAdjAcctUnit3 = null,
			string pInvAdjAcctUnit4 = null,
			int? DateOffset = null,
			int? TaskId = null,
			string rInfobar = null);
	}
}

