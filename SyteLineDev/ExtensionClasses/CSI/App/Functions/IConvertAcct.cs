//PROJECT NAME: Data
//CLASS NAME: IConvertAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvertAcct
	{
		string ConvertAcctFn(
			string OldAcct,
			int? RawAcctFlds,
			string FillFmt1,
			string FillFmt2,
			string FillFmt3,
			int? RawAcctPos1,
			int? RawAcctPos2,
			int? AcctLen1,
			int? AcctLen2,
			int? AcctChar1,
			string NilAcct,
			string LeadingSpaceChar);
	}
}

