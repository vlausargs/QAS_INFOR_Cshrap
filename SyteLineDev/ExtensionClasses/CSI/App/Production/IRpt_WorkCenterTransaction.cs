//PROJECT NAME: Production
//CLASS NAME: IRpt_WorkCenterTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRpt_WorkCenterTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_WorkCenterTransactionSp(string TransGroup = null,
		string WorkCentereStart = null,
		string WorkCenterEnd = null,
		string EmployeeStart = null,
		string EmployeeEnd = null,
		DateTime? TransDateStart = null,
		DateTime? TransDateEnd = null,
		string ShiftStart = null,
		string ShiftEnd = null,
		string TransType = null,
		string DocNumStart = null,
		string DocNumEnd = null,
		string BackflushTrans = null,
		int? PStartRecDateOffset = null,
		int? PEndRecDateOffset = null,
		string PrintCost = null,
		string pSite = null,
		string BGUser = null);
	}
}

