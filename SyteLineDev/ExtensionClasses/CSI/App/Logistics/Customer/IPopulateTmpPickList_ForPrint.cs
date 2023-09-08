//PROJECT NAME: Logistics
//CLASS NAME: IPopulateTmpPickList_ForPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPopulateTmpPickList_ForPrint
	{
		int? PopulateTmpPickList_ForPrintSp(string Status,
		int? Selected,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Picker,
		int? Printed,
		DateTime? PickDate,
		string Whse,
		string PackLoc,
		Guid? ProcessId1,
		Guid? ProcessId2,
		int? GenerateBulkPickList);
	}
}

