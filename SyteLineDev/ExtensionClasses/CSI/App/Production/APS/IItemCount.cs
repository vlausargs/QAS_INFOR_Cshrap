//PROJECT NAME: Production
//CLASS NAME: IItemCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IItemCount
	{
		(int? ReturnCode, string Infobar) ItemCountSp(string Item,
		string Infobar);
	}
}

