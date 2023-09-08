//PROJECT NAME: Production
//CLASS NAME: IBflushLotVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBflushLotVal
	{
		(int? ReturnCode, string Infobar) BflushLotValSp(string Whse,
		string Lot,
		int? Selected,
		string JobMatlItem,
		string Loc,
		string Infobar,
		string RefNum,
		int? OperNum);
	}
}

