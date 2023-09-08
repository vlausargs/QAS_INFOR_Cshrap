//PROJECT NAME: Production
//CLASS NAME: IProcessMilestoneEvents.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProcessMilestoneEvents
	{
		(int? ReturnCode, string Infobar) ProcessMilestoneEventsSp(string PProjNum,
		int? IsInvoicePosted = 0,
		int? ChkProjMSOnOblig = 0,
		string Infobar = null);
	}
}

