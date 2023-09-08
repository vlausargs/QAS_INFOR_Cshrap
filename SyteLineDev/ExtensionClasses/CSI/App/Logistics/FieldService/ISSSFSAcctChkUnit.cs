//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcctChkUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcctChkUnit
	{
		(int? ReturnCode,
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4) SSSFSAcctChkUnitSp(
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4);
	}
}

