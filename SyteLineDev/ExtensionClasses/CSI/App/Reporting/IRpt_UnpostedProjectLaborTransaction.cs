//PROJECT NAME: Reporting
//CLASS NAME: IRpt_UnpostedProjectLaborTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_UnpostedProjectLaborTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_UnpostedProjectLaborTransactionSp(string ProjectStarting = null,
		string ProjectEnding = null,
		int? TaskStarting = null,
		int? TaskEnding = null,
		DateTime? TransactionDateStarting = null,
		DateTime? TransactionDateEnding = null,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		int? DateStartingOffSET = null,
		int? DateEndingOffSET = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		Guid? PSessionID = null,
		string pSite = null);
	}
}

