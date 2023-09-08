//PROJECT NAME: Production
//CLASS NAME: IShiftSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IShiftSave
	{
		int? ShiftSaveSp(string ShiftId,
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

