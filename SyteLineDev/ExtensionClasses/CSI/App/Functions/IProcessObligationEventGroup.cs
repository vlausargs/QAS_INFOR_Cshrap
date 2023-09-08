//PROJECT NAME: Data
//CLASS NAME: IProcessObligationEventGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProcessObligationEventGroup
	{
		(int? ReturnCode,
			string Infobar) ProcessObligationEventGroupSp(
			string PProjNum,
			string CostClass,
			string MsType,
			string MsGroup,
			int? MsTask,
			int? IsInvoicePosted,
			string Infobar);
	}
}

