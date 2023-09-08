//PROJECT NAME: Data
//CLASS NAME: IItemSetNc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemSetNc
	{
		(int? ReturnCode,
			string Infobar) ItemSetNcSp(
			string Item,
			int? RaiseWarning = 1,
			string Infobar = null);
	}
}

