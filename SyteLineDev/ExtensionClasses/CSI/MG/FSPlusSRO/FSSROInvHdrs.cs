//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROInvHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSSROInvHdrs")]
	public class FSSROInvHdrs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROInvSp(string PMode,
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
		[Optional, DefaultParameterValue("S")] string SortBy,
		[Optional, DefaultParameterValue(0)] int? InclBillHold,
		[Optional, DefaultParameterValue("I")] string OperationStatus,
		ref string StartInvNum,
		ref string EndInvNum,
		ref string Infobar)
		{
			var iSSSFSSROInvExt = new SSSFSSROInvFactory().Create(this, true);
			
			var result = iSSSFSSROInvExt.SSSFSSROInvSp(PMode,
			PBegSroNum,
			PEndSroNum,
			PBegSroLine,
			PEndSroLine,
			PBegSroOper,
			PEndSroOper,
			PBegBillMgr,
			PEndBillMgr,
			PBegCustNum,
			PEndCustNum,
			PBegRegion,
			PEndRegion,
			PBegTransDate,
			PEndTransDate,
			PBegCloseDate,
			PEndCloseDate,
			PInclCalculated,
			PInclProject,
			PInvCred,
			PInvDate,
			PTransDom,
			SortBy,
			InclBillHold,
			OperationStatus,
			StartInvNum,
			EndInvNum,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			StartInvNum = result.StartInvNum;
			EndInvNum = result.EndInvNum;
			Infobar = result.Infobar;
			return Severity;
		}

	}
}
