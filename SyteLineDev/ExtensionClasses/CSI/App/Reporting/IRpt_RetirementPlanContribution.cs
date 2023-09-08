//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RetirementPlanContribution.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RetirementPlanContribution
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RetirementPlanContributionSp(string DeparmentStarting = null,
		string DeparmentEnding = null,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		DateTime? CheckDateStarting = null,
		DateTime? CheckDateEnding = null,
		string DECodeStarting = null,
		string DECodeEnding = null,
		string DECodeType = null,
		string EmployeeTypes = null,
		int? CheckDateStartingOffset = null,
		int? CheckDateEndingOffset = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null);
	}
}

