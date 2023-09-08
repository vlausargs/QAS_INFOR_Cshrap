//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobTickets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobTickets
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobTicketsSp(string StartJob = null,
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
		int? JobTickets132 = null,
		int? NumTickets = null,
		int? StartJobDateOffset = null,
		int? EndJobDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

