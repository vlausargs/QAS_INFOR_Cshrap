//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MasterPlanning.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MasterPlanning
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MasterPlanningSp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? MPSItemsOnly = null,
		int? DisplayMPSExceptions = null,
		int? DisplayHeader = null,
		string pSite = null,
		string MessageLanguage = null);
	}
}

