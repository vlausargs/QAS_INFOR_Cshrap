//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_PrintBankReconciliation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_PrintBankReconciliation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PrintBankReconciliationSp(string PBankCode,
		string pSite = null);
	}
}

