//PROJECT NAME: Logistics
//CLASS NAME: IPurgeTmpPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPurgeTmpPickList
	{
		int? PurgeTmpPickListSp(Guid? processid);
	}
}

