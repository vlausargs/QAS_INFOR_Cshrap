//PROJECT NAME: Admin
//CLASS NAME: IAppWorkflowParmUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IAppWorkflowParmUpdate
	{
		int? AppWorkflowParmUpdateSp(string Name1,
		string Value1,
		string Name2,
		string Value2,
		string Name3,
		string Value3);
	}
}

