//PROJECT NAME: Admin
//CLASS NAME: IAppWorkflowUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IAppWorkflowUpdate
	{
		int? AppWorkflowUpdateSp(Guid? EventHandlerRP,
		int? Active,
		string AppName,
		int? CreateTrigger);
	}
}

