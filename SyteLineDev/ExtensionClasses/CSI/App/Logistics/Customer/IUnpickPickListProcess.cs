//PROJECT NAME: Logistics
//CLASS NAME: IUnpickPickListProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUnpickPickListProcess
	{
		(int? ReturnCode, string InfoBar) UnpickPickListProcessSp(Guid? processid,
		string InfoBar);
	}
}

