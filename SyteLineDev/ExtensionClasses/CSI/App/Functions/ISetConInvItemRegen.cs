//PROJECT NAME: Data
//CLASS NAME: ISetConInvItemRegen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetConInvItemRegen
	{
		int? SetConInvItemRegenSp(
			string CoNum);
	}
}

