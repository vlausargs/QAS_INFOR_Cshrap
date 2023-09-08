//PROJECT NAME: Data
//CLASS NAME: IConInvPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConInvPost
	{
		(int? ReturnCode,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			string DoHdrList,
			int? PrintConInvReport) ConInvPostSp(
			Guid? SessionId,
			string PInvNum,
			DateTime? PInvDate,
			string PStartCustNum,
			string PEndCustNum,
			string PStartDoNum,
			string PEndDoNum,
			string PStartCustPoNum,
			string PEndCustPoNum,
			string PMooreForm,
			int? PInclNonDraft,
			int? PLCR,
			int? POrderNums,
			int? PEuroTotal,
			int? PTransToDom,
			int? PSerialNums,
			int? PPlanItemMats,
			string PConfigDetails,
			int? PItemTypeItem,
			int? PItemTypeCust,
			int? PBillToText,
			int? PStdOrderText,
			string PLineRelText,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			string DoHdrList,
			int? PrintConInvReport,
			decimal? PStartingShipment,
			decimal? PEndingShipment);
	}
}

