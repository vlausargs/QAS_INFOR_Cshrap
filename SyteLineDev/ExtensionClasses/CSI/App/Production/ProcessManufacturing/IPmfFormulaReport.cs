//PROJECT NAME: Production
//CLASS NAME: IPmfFormulaReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFormulaReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfFormulaReportSp(
			int? Seq,
			Guid? SessionId,
			string SiteRef);
	}
}

