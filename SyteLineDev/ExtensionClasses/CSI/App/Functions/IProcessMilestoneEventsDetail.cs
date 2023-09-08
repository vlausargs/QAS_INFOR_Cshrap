//PROJECT NAME: Data
//CLASS NAME: IProcessMilestoneEventsDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProcessMilestoneEventsDetail
	{
		(int? ReturnCode,
			string Infobar) ProcessMilestoneEventsDetailSp(
			string PProjNum,
			string MsGroup,
			int? IsInvoicePosted = 0,
			string Infobar = null);
	}
}

