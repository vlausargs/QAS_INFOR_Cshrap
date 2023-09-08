//PROJECT NAME: Production
//CLASS NAME: IPmfFormulaDetReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFormulaDetReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfFormulaDetReportSp(
			int? Seq,
			Guid? SessionId,
			string SiteRef);
	}
}

