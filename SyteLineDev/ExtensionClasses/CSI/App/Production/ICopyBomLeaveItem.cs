//PROJECT NAME: Production
//CLASS NAME: ICopyBomLeaveItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICopyBomLeaveItem
	{
		(int? ReturnCode, string PsNum,
		string Item,
		string Job,
		int? Suffix,
		string ItemRev,
		int? StartOper,
		int? EndOper,
		string Infobar) CopyBomLeaveItemSp(string FromCategory,
		string PsNum,
		string Item,
		string Job,
		int? Suffix,
		string ItemRev,
		int? StartOper,
		int? EndOper,
		string Infobar);
	}
}

