//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_ContractProfitAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_ContractProfitAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ContractProfitAnalysisSp(string BegContract = null,
		string EndContract = null,
		string BegCustNum = null,
		string EndCustNum = null,
		DateTime? BegInvoiceDate = null,
		DateTime? EndInvoiceDate = null,
		int? ShowSro = 1,
		string pSite = null);
	}
}

