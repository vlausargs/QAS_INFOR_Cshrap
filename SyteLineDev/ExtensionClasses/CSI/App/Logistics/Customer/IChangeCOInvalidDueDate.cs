//PROJECT NAME: Logistics
//CLASS NAME: IChangeCOInvalidDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IChangeCOInvalidDueDate
	{
		(int? ReturnCode, string Infobar) ChangeCOInvalidDueDateSp(int? Selected,
		string OrderNum,
		int? Line,
		int? Release,
		string Status,
		DateTime? OldDueDate,
		DateTime? NewDueDate,
		string ShipSite,
		string Infobar);
	}
}

