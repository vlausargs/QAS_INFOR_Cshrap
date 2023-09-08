//PROJECT NAME: Material
//CLASS NAME: ILotValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ILotValid
	{
		(int? ReturnCode, string Infobar) LotValidSp(string Whse,
		string Item,
		string Lot,
		string Infobar);
	}
}

