//PROJECT NAME: Data
//CLASS NAME: ICredChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICredChk
	{
		(int? ReturnCode,
			string Infobar) CredChkSp(
			string CustNum,
			decimal? Adjust = 0,
			int? AlwaysWarn = 0,
			int? AbortCredCk = 0,
			int? OrderChg = 0,
			string CoNum = null,
			int? CreditHold = 0,
			string OrigSite = null,
			int? NoMsg = 0,
			int? RollbackOnError = 0,
			string Infobar = null,
			int? CoLine = null,
			int? CoRelease = null,
			int? SkipUpdObal = null,
			int? CustChanged = 0,
			decimal? AdjustForCreditHold = null);
	}
}

