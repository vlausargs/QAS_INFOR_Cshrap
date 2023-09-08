//PROJECT NAME: Logistics
//CLASS NAME: ICanConfigureItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICanConfigureItem
	{
		(int? ReturnCode, int? OplConfigureItem,
		int? OplConfigureDone) CanConfigureItemSp(string IpcItem,
		int? OplConfigureItem,
		int? OplConfigureDone);
	}
}

