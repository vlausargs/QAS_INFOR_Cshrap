//PROJECT NAME: Reporting
//CLASS NAME: IRpt_LettersofCreditbyCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_LettersofCreditbyCustomer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_LettersofCreditbyCustomerSp(string SCustNum = null,
		string ECustNum = null,
		string LcrStat = null,
		string CurrCode = null,
		int? ShowDetail = null,
		string SLcrNum = null,
		string ELcrNum = null,
		DateTime? StIssueDate = null,
		DateTime? EIssueDate = null,
		DateTime? SCloseDate = null,
		DateTime? ECloseDate = null,
		int? SIssueDateOffSET = null,
		int? EIssueDateOffSET = null,
		int? SCloseDateOffSET = null,
		int? ECloseDateOffSET = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

