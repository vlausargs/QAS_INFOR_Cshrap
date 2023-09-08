//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROReadyToInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROReadyToInvoice
	{
		int? SSSFSSROReadyToInvoiceFn(
			string SroNum);
	}
}

