//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCredChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCredChk
	{
		(int? ReturnCode,
			string Infobar,
			string Warning) SSSPOSCredChkSp(
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
			string Warning = null);
	}
}

