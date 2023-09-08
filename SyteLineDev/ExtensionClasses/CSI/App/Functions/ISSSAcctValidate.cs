//PROJECT NAME: Data
//CLASS NAME: ISSSAcctValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSAcctValidate
	{
		(int? ReturnCode,
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4,
			string Infobar) SSSAcctValidateSp(
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4,
			string Infobar);
	}
}

