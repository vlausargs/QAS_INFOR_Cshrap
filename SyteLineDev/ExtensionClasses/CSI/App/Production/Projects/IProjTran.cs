//PROJECT NAME: Production
//CLASS NAME: IProjTran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjTran
	{
		(int? ReturnCode,
			string Infobar,
			decimal? ProjTransNum) ProjTranSp(
			string PProjNum,
			int? PTaskNum,
			int? PSeq,
			string PType,
			string PCostCode,
			decimal? PTransNum,
			DateTime? PTransDate,
			decimal? PAmount,
			string PTransType,
			string PItem,
			decimal? PQty,
			decimal? PTotCost,
			decimal? PTotMatlCost,
			decimal? PTotLbrCost,
			decimal? PTotFovhdCost,
			decimal? PTotVovhdCost,
			decimal? PTotOutCost,
			string PEmpNum,
			string PPayType,
			string PShift,
			decimal? PAHrs,
			decimal? PPrRate,
			decimal? PProjRate,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PRefStr,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null,
			string PJobCostCode = null,
			Guid? RowPointer = null,
			string FromNoteObject = null,
			Guid? FromNoteRowPointer = null,
			string DocumentNum = null,
			decimal? ProjTransNum = null);
	}
}

