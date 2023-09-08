//PROJECT NAME: Logistics
//CLASS NAME: IUpdateOldInvoiceNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateOldInvoiceNum
	{
		int? UpdateOldInvoiceNumSp(int? InvLength);
	}
}

