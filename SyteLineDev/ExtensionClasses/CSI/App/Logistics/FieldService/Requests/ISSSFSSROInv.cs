//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROInv
	{
		(int? ReturnCode, string StartInvNum,
		string EndInvNum,
		string Infobar) SSSFSSROInvSp(string PMode,
		string PBegSroNum,
		string PEndSroNum,
		int? PBegSroLine,
		int? PEndSroLine,
		int? PBegSroOper,
		int? PEndSroOper,
		string PBegBillMgr,
		string PEndBillMgr,
		string PBegCustNum,
		string PEndCustNum,
		string PBegRegion,
		string PEndRegion,
		DateTime? PBegTransDate,
		DateTime? PEndTransDate,
		DateTime? PBegCloseDate,
		DateTime? PEndCloseDate,
		int? PInclCalculated,
		int? PInclProject,
		string PInvCred,
		DateTime? PInvDate,
		int? PTransDom,
		string SortBy = "S",
		int? InclBillHold = 0,
		string OperationStatus = "I",
		string StartInvNum = null,
		string EndInvNum = null,
		string Infobar = null);
	}
}

