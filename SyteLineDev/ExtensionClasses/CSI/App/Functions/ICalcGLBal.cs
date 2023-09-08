//PROJECT NAME: Data
//CLASS NAME: ICalcGLBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcGLBal
	{
		decimal? CalcGLBalFn(
			int? DebitFlag,
			string Year,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4);
	}
}

