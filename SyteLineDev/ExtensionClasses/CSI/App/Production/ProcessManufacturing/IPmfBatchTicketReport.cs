//PROJECT NAME: Production
//CLASS NAME: IPmfBatchTicketReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfBatchTicketReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfBatchTicketReportSp(
			int? Seq,
			Guid? SessionId,
			string SiteRef);
	}
}

