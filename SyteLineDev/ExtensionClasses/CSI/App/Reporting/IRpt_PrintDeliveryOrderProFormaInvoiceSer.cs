//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintDeliveryOrderProFormaInvoiceSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintDeliveryOrderProFormaInvoiceSer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintDeliveryOrderProFormaInvoiceSerSp(string DoNum,
		int? DoLine,
		int? DoSeq,
		string pSite = null);
	}
}

