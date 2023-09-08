//PROJECT NAME: Data
//CLASS NAME: ICalcOtherDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcOtherDate
	{
		(int? ReturnCode,
			DateTime? NewOtherDate,
			string Infobar) CalcOtherDateSp(
			string PTrnNum,
			DateTime? PKnownDate,
			string PItem,
			int? CalcShipDate,
			DateTime? NewOtherDate,
			string Infobar);
	}
}

