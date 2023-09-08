//PROJECT NAME: Data
//CLASS NAME: IItemMcl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemMcl
	{
		(int? ReturnCode,
			DateTime? NewShipDate,
			string Infobar) ItemMclSp(
			DateTime? PShipDate,
			int? CalcShipDate,
			int? PTrnTime,
			int? PDockTime,
			DateTime? NewShipDate,
			string Infobar,
			string Site = null);
	}
}

