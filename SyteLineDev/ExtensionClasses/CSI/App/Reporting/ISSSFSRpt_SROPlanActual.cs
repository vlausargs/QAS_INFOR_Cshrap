//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROPlanActual.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROPlanActual
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPlanActualSp(string SRONumBeg = null,
		string SRONumEnd = null,
		int? SROLineBeg = null,
		int? SROLineEnd = null,
		int? SROOperBeg = null,
		int? SROOperEnd = null,
		string ItemBeg = null,
		string ItemEnd = null,
		string WCBeg = null,
		string WCEnd = null,
		string MCBeg = null,
		string MCEnd = null,
		string CostPrice = "P",
		string pSite = null);
	}
}

