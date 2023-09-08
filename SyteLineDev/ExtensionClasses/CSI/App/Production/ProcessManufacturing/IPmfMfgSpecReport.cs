//PROJECT NAME: Production
//CLASS NAME: IPmfMfgSpecReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfMfgSpecReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfMfgSpecReportSp(
			int? Seq,
			Guid? SessionId,
			string SiteRef);
	}
}

