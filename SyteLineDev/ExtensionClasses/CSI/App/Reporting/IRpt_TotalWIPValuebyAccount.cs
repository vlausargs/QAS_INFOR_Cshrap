//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TotalWIPValuebyAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TotalWIPValuebyAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TotalWIPValuebyAccountSp(string SAcct = null,
		string EAcct = null,
		string ExBegproductcode = null,
		string ExEndProductcode = null,
		string ExBegItem = null,
		string ExEndItem = null,
		string ExBegjob = null,
		string ExEndJob = null,
		int? ExBegSuffix = null,
		int? ExEndSuffix = null,
		string ExOptgoJJobStat = null,
		int? PUnitCode1 = 0,
		int? PUnitCode2 = 0,
		int? PUnitCode3 = 0,
		int? PUnitCode4 = 0,
		int? Displayheader = null,
		string SRONumBeg = null,
		string SRONumEnd = null,
		string SROOperStatus = null,
		string pSite = null);
	}
}

