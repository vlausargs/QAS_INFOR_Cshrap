//PROJECT NAME: Admin
//CLASS NAME: IAppWorkflowCreateEventTrigger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IAppWorkflowCreateEventTrigger
	{
		(int? ReturnCode,
			string Infobar) AppWorkflowCreateEventTriggerSp(
			Guid? EventHandlerRowPointer,
			string Infobar);
	}
}

