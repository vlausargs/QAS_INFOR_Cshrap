//PROJECT NAME: Data
//CLASS NAME: IUobChcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUobChcr
	{
		(int? ReturnCode,
			string Infobar) UobChcrSp(
			string CustNum,
			decimal? Adjust,
			int? AlwaysWarn,
			int? AbortCredCk,
			string CoNum,
			string Infobar,
			int? CoLine = null,
			int? CoRelease = null,
			int? CustChanged = 0,
			decimal? AdjustForCreditHold = null);
	}
}

