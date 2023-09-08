//PROJECT NAME: Data
//CLASS NAME: IJmatlP2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJmatlP2
	{
		(int? ReturnCode,
			decimal? TransNum,
			decimal? TotPost,
			Guid? MatltranAmtRowPointer,
			string Infobar) JmatlP2Sp(
			string CallFrom,
			Guid? ItemRowPointer,
			Guid? ItemwhseRowPointer,
			Guid? ItemlocRowPointer,
			Guid? MatltranRowPointer,
			Guid? WcRowPointer,
			Guid? JobmatlRowPointer,
			Guid? JobrouteRowPointer,
			Guid? JobItemRowPointer,
			Guid? JobRowPointer,
			Guid? ProdcodeRowPointer,
			Guid? ProdvarRowPointer,
			string TransType,
			decimal? Qty,
			decimal? AdjQty,
			DateTime? TransDate,
			string TransClass,
			int? ByProduct,
			string CostCode,
			string Loc,
			string Lot,
			string CurUserCode,
			int? CoBy,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string ImportDocId = null,
			decimal? TransNum = null,
			decimal? TotPost = null,
			Guid? MatltranAmtRowPointer = null,
			string Infobar = null);
	}
}

