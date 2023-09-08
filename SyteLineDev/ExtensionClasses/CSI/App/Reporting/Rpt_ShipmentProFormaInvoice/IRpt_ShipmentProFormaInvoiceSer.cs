//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ShipmentProFormaInvoiceSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ShipmentProFormaInvoiceSer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentProFormaInvoiceSerSp(decimal? ShipmentID,
		int? ShipmentLine,
		int? ShipmentSeq,
		string pSite = null);
	}
}

