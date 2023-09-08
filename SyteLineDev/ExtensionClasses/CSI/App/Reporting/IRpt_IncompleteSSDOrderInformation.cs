//PROJECT NAME: Reporting
//CLASS NAME: IRpt_IncompleteSSDOrderInformation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_IncompleteSSDOrderInformation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_IncompleteSSDOrderInformationSp(DateTime? PStartingPeriod = null,
		DateTime? PEndingPeriod = null,
		int? PStartingPeriodOffset = null,
		int? PEndingPeriodOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

