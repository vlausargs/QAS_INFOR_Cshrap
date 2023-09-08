//PROJECT NAME: Production
//CLASS NAME: IPmfBatchCloseReportJobList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfBatchCloseReportJobList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfBatchCloseReportJobListSp(
			string pn,
			string SiteRef);
	}
}

