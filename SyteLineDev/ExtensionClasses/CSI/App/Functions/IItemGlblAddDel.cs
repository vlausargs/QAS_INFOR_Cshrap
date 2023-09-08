//PROJECT NAME: Data
//CLASS NAME: IItemGlblAddDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemGlblAddDel
	{
		(int? ReturnCode,
			string Infobar) ItemGlblAddDelSp(
			string Item,
			string Site = null,
			string Mode = "ADD",
			string Infobar = null,
			string FromItem = null,
			int? CopyUetValues = 0);
	}
}

