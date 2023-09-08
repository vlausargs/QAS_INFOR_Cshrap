//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROWIPValuation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROWIPValuation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROWIPValuationSp(string BegProductCode = null,
		string EndProductCode = null,
		string BegItem = null,
		string EndItem = null,
		string BegSroNum = null,
		string EndSroNum = null,
		int? BegSroLine = null,
		int? EndSroLine = null,
		int? BegSroOper = null,
		int? EndSroOper = null,
		string BegOperCode = null,
		string EndOperCode = null,
		DateTime? BegOpenDate = null,
		DateTime? EndOpenDate = null,
		string BegSroType = null,
		string EndSroType = null,
		int? InclOpen = 1,
		int? InclInvoice = 1,
		int? InclDetail = 0,
		string pSite = null);
	}
}

