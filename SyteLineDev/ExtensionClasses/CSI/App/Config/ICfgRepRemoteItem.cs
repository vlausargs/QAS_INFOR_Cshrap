//PROJECT NAME: Config
//CLASS NAME: ICfgRepRemoteItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgRepRemoteItem
	{
		(int? ReturnCode,
			string Infobar) CfgRepRemoteItemSp(
			string Item,
			string CoNum,
			int? CoLine,
			string TrnNum,
			int? TrnLine,
			string Infobar);
	}
}

