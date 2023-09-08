//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PostedPayrollTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PostedPayrollTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PostedPayrollTransactionsSp(string ExOptdfEmplType = null,
		string ExBegDepart = null,
		string ExEndDepart = null,
		DateTime? ExBegCheckDate = null,
		DateTime? ExEndCheckDate = null,
		int? DateStartingOffSET = null,
		int? DateEndingOffSET = null,
		string ExBegEmp = null,
		string ExEndEmp = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null,
		int? IsSubReport = 0);
	}
}

