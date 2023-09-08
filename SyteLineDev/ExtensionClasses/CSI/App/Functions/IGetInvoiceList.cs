//PROJECT NAME: Data
//CLASS NAME: IGetInvoiceList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetInvoiceList
	{
		string GetInvoiceListFn(
			int? DirectDebitNum);
	}
}

