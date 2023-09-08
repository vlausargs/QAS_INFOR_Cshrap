//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcctValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcctValidate
	{
		(int? ReturnCode,
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4,
			string Infobar) SSSFSAcctValidateSp(
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4,
			string Infobar);
	}
}

