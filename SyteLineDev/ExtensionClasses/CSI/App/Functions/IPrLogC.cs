//PROJECT NAME: Data
//CLASS NAME: IPrLogC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrLogC
	{
		(int? ReturnCode,
			string Infobar) PrLogCSp(
			string Oper,
			string EmpNum,
			int? Seq,
			DateTime? WorkDate,
			string HrType,
			decimal? Hrs,
			decimal? PayRate,
			string Infobar,
			string PrlogAcct = null,
			string PrlogAcctUnit1 = null,
			string PrlogAcctUnit2 = null,
			string PrlogAcctUnit3 = null,
			string PrlogAcctUnit4 = null);
	}
}

