//PROJECT NAME: Production
//CLASS NAME: IShiftDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IShiftDel
	{
		(int? ReturnCode, string Infobar) ShiftDelSp(string PShift,
		Guid? RowPointer,
		int? AltNo,
		string Infobar);
	}
}

