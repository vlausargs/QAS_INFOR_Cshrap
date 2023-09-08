//PROJECT NAME: Material
//CLASS NAME: IMrpWbGenerateOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbGenerateOrder
	{
		(int? ReturnCode, string Infobar) MrpWbGenerateOrderSp(decimal? UserID,
		string RefTab,
		string PoparmsPoPrefix = null,
		string PoChange = null,
		int? BlanketQtyOver = null,
		int? PurchReqNotes = null,
		string PoparmsPrqPrefix = null,
		string SfcparmsWoPrefix = null,
		int? CopyCurrentBOM = null,
		int? CopyIndentedBOM = null,
		string SfcparmsPsPrefix = null,
		int? SingleOrder = null,
		string InvparmsTrnPrefix = null,
		Guid? SessionID = null,
		int? CopyToPSItemBOM = null,
		string Infobar = null,
		int? CreateTransitLoc = 0);
	}
}

