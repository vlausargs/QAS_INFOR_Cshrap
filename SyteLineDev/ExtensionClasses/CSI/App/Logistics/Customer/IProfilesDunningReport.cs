//PROJECT NAME: Logistics
//CLASS NAME: IProfilesDunningReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IProfilesDunningReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfilesDunningReportSp(string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PDunningGroup = null,
		int? PStartingDunningStage = null,
		int? PEndingDunningStage = null,
		string PSiteGroup = null,
		int? PCommit = 0,
		DateTime? PCutoffDate = null,
		int? PCutoffDateOffset = null,
		string pSite = null);
	}
}

