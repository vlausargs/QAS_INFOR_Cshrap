//PROJECT NAME: Data
//CLASS NAME: ISSSAcctChkUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSAcctChkUnit
	{
		(int? ReturnCode,
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4) SSSAcctChkUnitSp(
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4);
	}
}

