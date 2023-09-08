//PROJECT NAME: Logistics
//CLASS NAME: ICheckForActiveBGTask.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckForActiveBGTask
	{
		(int? ReturnCode, string Infobar) CheckForActiveBGTaskSp(string TaskName,
		string Infobar);
	}
}

