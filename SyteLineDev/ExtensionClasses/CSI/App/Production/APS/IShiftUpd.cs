//PROJECT NAME: Production
//CLASS NAME: IShiftUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IShiftUpd
	{
		int? ShiftUpdSp(string PShift,
		string Descr,
		int? SDay,
		string STime,
		int? EDay,
		string ETime,
		string MustCompFg,
		string OverrunFg,
		int? UpdateFlag,
		Guid? RowPointer,
		int? AltNo);
	}
}

