//PROJECT NAME: Logistics
//CLASS NAME: IUnshipShipment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUnshipShipment
	{
		(int? ReturnCode, int? FirstSequenceWithError,
		int? RecordsPosted,
		string PromptMsg,
		string PromptButtons,
		string InfoBar) UnshipShipmentSp(decimal? ShipmentId,
		string Whse,
		int? IgnoreLCR,
		int? IgnoreCount,
		int? ChangeStatus,
		int? Return2Stock,
		DateTime? TransDate,
		int? FirstSequenceWithError,
		int? RecordsPosted,
		string PromptMsg = null,
		string PromptButtons = null,
		string InfoBar = null);
	}
}

