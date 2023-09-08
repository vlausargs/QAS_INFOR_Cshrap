//PROJECT NAME: Logistics
//CLASS NAME: IUnpickPickListPopulate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUnpickPickListPopulate
	{
		(int? ReturnCode, string InfoBar) UnpickPickListPopulateSp(decimal? picklistid,
		Guid? processid,
		string InfoBar);
	}
}

