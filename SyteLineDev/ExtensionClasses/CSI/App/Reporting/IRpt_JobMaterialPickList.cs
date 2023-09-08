//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobMaterialPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobMaterialPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobMaterialPickListSp(string StartJob = null,
		string EndJob = null,
		int? StartSuffix = null,
		int? EndSuffix = null,
		string JobStat = null,
		string StartItem = null,
		string EndItem = null,
		string StartProdMix = null,
		string EndProdMix = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? StartOpera = null,
		int? EndOpera = null,
		int? MatlLst132 = null,
		int? MatlLstDate = null,
		int? PickByLoc = null,
		int? PrintSN = null,
		int? PrintBCFmt = null,
		int? PageOpera = null,
		int? PrintSecLoc = null,
		int? ExtScrapFact = null,
		string ReprintPick = null,
		int? DisplayRefFields = null,
		int? StartJobDateOffset = null,
		int? EndJobDateOffset = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

