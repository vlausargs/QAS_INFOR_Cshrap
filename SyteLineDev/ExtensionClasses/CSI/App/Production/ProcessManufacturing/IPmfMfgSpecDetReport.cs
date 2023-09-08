//PROJECT NAME: Production
//CLASS NAME: IPmfMfgSpecDetReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfMfgSpecDetReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfMfgSpecDetReportSp(
			int? Seq,
			Guid? SessionId,
			Guid? SpecRp,
			string SiteRef);
	}
}

