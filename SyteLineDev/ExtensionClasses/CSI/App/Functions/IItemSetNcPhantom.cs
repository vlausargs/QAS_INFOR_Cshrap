//PROJECT NAME: Data
//CLASS NAME: IItemSetNcPhantom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemSetNcPhantom
	{
		(int? ReturnCode,
			string Infobar) ItemSetNcPhantomSp(
			string Item,
			int? RaiseWarning = 1,
			string Infobar = null);
	}
}

