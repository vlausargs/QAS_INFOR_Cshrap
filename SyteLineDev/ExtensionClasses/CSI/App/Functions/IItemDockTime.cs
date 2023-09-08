//PROJECT NAME: Data
//CLASS NAME: IItemDockTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemDockTime
	{
		(int? ReturnCode,
			int? TDockTime,
			string Infobar) ItemDockTimeSp(
			string PItem,
			int? TDockTime,
			string Infobar,
			string Site = null);
	}
}

