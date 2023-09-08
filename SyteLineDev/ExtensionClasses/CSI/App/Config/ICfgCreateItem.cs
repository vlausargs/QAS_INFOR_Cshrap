//PROJECT NAME: Config
//CLASS NAME: ICfgCreateItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCreateItem
	{
		(int? ReturnCode,
			string Infobar) CfgCreateItemSp(
			string pBaseItem,
			string pNewItem,
			int? pItemExists,
			string pConfigId,
			int? RepRemote,
			string Infobar);
	}
}

