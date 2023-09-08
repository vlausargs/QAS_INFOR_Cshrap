//PROJECT NAME: Data
//CLASS NAME: IGetNextLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetNextLot
	{
		(int? ReturnCode,
			string NextLot,
			string Infobar) GetNextLotSp(
			string Item,
			string Site,
			string RefNum,
			int? RefLine,
			string RefType,
			string NextLot,
			string Infobar);
	}
}

