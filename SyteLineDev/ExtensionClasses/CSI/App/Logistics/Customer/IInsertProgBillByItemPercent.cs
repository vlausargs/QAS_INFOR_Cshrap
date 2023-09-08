//PROJECT NAME: Logistics
//CLASS NAME: IInsertProgBillByItemPercent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInsertProgBillByItemPercent
	{
		(int? ReturnCode, string Infobar) InsertProgBillByItemPercentSp(string CoNum,
		int? CoLine,
		string InvoiceFlag,
		DateTime? BillDate,
		string Description,
		int? Percent,
		string Infobar);
	}
}

