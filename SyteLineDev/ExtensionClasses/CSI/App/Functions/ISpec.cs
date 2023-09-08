//PROJECT NAME: Data
//CLASS NAME: ISpec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISpec
	{
		(int? ReturnCode,
			int? NextRow,
			int? THadError,
			string Infobar) SpecSp(
			string PItem,
			DateTime? PDueDate,
			decimal? PQtyReq,
			decimal? POrigQty,
			string POrderType,
			string PReference,
			int? PRefLineSuf,
			int? PRefRel,
			string PXrefType,
			string PXrefNum,
			int? PXrefLinSuf,
			int? PXrefRelease,
			int? ReqMday,
			int? TExcAhd,
			int? TExcBhd,
			int? TExcAhdJ,
			int? TExcBhdJ,
			int? NextRow,
			int? THadError,
			string Infobar,
			int? MrpParmDynLead = null,
			int? ItemDockTime = null,
			DateTime? CurrentDate = null,
			int? BufferExcMesg = 0,
			Guid? ProcessId = null,
			int? BgTaskID = null,
			int? MrpParmUseSchedTimesInPlanning = null,
			string ApsParmApsMode = null);
	}
}

