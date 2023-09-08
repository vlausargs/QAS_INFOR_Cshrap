//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PR01crpDoChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PR01crpDoChecks
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PR01crpDoChecksSp(string pSessionIDChar = null,
		int? pNewPrCheck = null,
		int? pMaskEmployeeSSN = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
}

