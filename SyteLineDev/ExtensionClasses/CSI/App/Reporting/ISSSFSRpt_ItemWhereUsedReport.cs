//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_ItemWhereUsedReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_ItemWhereUsedReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ItemWhereUsedReportSp(string pItem,
		string pSerNum,
		string pRevision,
		string pMfgNum,
		string pCustomerConsumer,
		string pSite = null);
	}
}

