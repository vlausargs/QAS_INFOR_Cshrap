//PROJECT NAME: Material
//CLASS NAME: IIsItemNotInInventory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IIsItemNotInInventory
	{
		(int? ReturnCode, int? ItemNotInInventory) IsItemNotInInventorySp(string Item,
		int? ItemNotInInventory);
	}
}

