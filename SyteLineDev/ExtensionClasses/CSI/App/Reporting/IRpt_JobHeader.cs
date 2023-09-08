//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobHeaderSp(string StartJob = null,
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
			int? JobHdrDate = null,
			int? PrintBCFmt = null,
			int? StartJobDateOffset = null,
			int? EndJobDateOffset = null,
			int? JobShowInternal = null,
			int? JobShowExternal = null,
			int? DisplayHeader = null,
			string BGSessionId = null,
			string pSite = null);
	}
}

