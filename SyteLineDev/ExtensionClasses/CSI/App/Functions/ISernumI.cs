//PROJECT NAME: Data
//CLASS NAME: ISernumI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISernumI
	{
		(int? ReturnCode,
			string Infobar) SernumISp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			decimal? TargetQty,
			Guid? TmpSerId,
			decimal? RsvdInvRsvdNum,
			string Infobar,
			string PImportDocId = null,
			int? PCalledFromPickWorkbench = null);
	}
}

