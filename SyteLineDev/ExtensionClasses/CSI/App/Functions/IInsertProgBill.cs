//PROJECT NAME: Data
//CLASS NAME: IInsertProgBill.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInsertProgBill
	{
		(int? ReturnCode,
			string Infobar) InsertProgBillSp(
			string CoNum,
			int? CoLine,
			string InvoiceFlag,
			DateTime? BillDate,
			string Description,
			decimal? BillAmount,
			string Infobar);
	}
}

