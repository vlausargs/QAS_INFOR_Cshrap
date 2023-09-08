//PROJECT NAME: Production
//CLASS NAME: IRSQC_HomeAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_HomeAlerts
	{
		(int? ReturnCode, int? PastDueSReceivers,
		int? PastDueOReceivers,
		int? PastDueRReceivers,
		int? PastDueJReceivers,
		int? PastDuePReceivers,
		int? PastDueMRR,
		int? PastDueCAR,
		int? PastDueTRR,
		int? PastDueCMR,
		int? PastDueCOC,
		int? PastDueTM,
		int? PastDueCM,
		int? PastDueCC,
		int? PastDueGages1,
		int? PastDueGages2) RSQC_HomeAlertsSp(int? PastDueSReceivers,
		int? PastDueOReceivers,
		int? PastDueRReceivers,
		int? PastDueJReceivers,
		int? PastDuePReceivers,
		int? PastDueMRR,
		int? PastDueCAR,
		int? PastDueTRR,
		int? PastDueCMR,
		int? PastDueCOC,
		int? PastDueTM,
		int? PastDueCM,
		int? PastDueCC,
		int? PastDueGages1,
		int? PastDueGages2);
	}
}

