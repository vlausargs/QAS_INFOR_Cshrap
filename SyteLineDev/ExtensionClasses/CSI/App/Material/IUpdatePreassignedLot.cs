//PROJECT NAME: Material
//CLASS NAME: IUpdatePreassignedLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdatePreassignedLot
	{
		(int? ReturnCode, string Infobar) UpdatePreassignedLotSp(int? Select,
		string Lot,
		string sQtyRec,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		string Infobar);
	}
}

