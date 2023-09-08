//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SalesCommissionbySalesperson.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SalesCommissionbySalesperson
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalesCommissionbySalespersonSp(string StartSalesman = null,
		string EndSalesman = null,
		string StartClass = null,
		string EndClass = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		string CommStatus = null,
		int? PrintPaidRec = null,
		int? PageForSalesman = null,
		int? PrintPaymentDetail = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? PDisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

