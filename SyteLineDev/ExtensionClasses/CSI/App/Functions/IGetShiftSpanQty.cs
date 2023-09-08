//PROJECT NAME: Data
//CLASS NAME: IGetShiftSpanQtySp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetShiftSpanQty
	{
		int? GetShiftSpanQtySp(
			DateTime? TransDate,
			string Shift);
	}
}

