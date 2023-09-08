//PROJECT NAME: Logistics
//CLASS NAME: IPurgeTmpPickListLocSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPurgeTmpPickListLocSerial
	{
		int? PurgeTmpPickListLocSerialSp(Guid? processid);
	}
}

