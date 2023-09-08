//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROLoanersAndExchanges.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROLoanersAndExchanges
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROLoanersAndExchangesSp(string Mode = "LS",
		string BegSroNum = null,
		string EndSroNum = null,
		string BegCustNum = null,
		string EndCustNum = null,
		int? BegSroLine = null,
		int? EndSroLine = null,
		int? BegSroOper = null,
		int? EndSroOper = null,
		string BegItem = null,
		string EndItem = null,
		string BegUnit = null,
		string EndUnit = null,
		string BegBillMgr = null,
		string EndBillMgr = null,
		DateTime? BegStartDate = null,
		DateTime? EndStartDate = null,
		DateTime? BegEndDate = null,
		DateTime? EndEndDate = null,
		DateTime? BegOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? BegDueDate = null,
		DateTime? EndDueDate = null,
		string pSite = null);
	}
}

