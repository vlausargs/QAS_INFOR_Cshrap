//PROJECT NAME: Material
//CLASS NAME: ICheckConsgnWhseForItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckConsgnWhseForItem
	{
		(int? ReturnCode,
		string Infobar) CheckConsgnWhseForItemSp(
			string Item,
			string Whse,
			string Infobar);
	}
}

