//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROCredChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROCredChk
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROCredChkSp(
			string CustNum = null,
			decimal? Adjust = 0,
			int? AlwaysWarn = 0,
			int? AbortCredCk = 0,
			int? OrderChg = 0,
			string SRONum = null,
			int? SroLine = null,
			int? SroOper = null,
			int? CreditHold = null,
			int? NoMsg = 0,
			int? RollbackOnError = 0,
			string Infobar = null);
	}
}

