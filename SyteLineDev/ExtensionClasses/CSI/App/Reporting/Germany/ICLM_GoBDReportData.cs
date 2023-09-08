//PROJECT NAME: Reporting
//CLASS NAME: ICLM_GoBDReportData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.Germany
{
	public interface ICLM_GoBDReportData
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GoBDReportDataSp(
			DateTime? TransDateBeg,
			DateTime? TransDateEnd,
			string pSessionIDChar = null,
			string CollectionName = null);
	}
}

