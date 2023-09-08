//PROJECT NAME: Data
//CLASS NAME: INextLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextLot
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextLotSp(
			string Item,
			int? UseParm,
			string Prefix,
			string Key,
			string Infobar,
			string Site = null,
			int? NoExpKey = null);
	}
}

