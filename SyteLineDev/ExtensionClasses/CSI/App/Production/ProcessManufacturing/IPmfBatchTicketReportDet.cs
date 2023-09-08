//PROJECT NAME: Production
//CLASS NAME: IPmfBatchTicketReportDet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfBatchTicketReportDet
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfBatchTicketReportDetSp(
			int? Seq,
			Guid? SessionId,
			Guid? JobRp,
			string SiteRef);
	}
}

