//PROJECT NAME: Codes
//CLASS NAME: IShiftExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IShiftExists
	{
		(int? ReturnCode, int? ShiftExists,
		string Infobar) ShiftExistsSp(string Shift,
		int? ShiftExists,
		string Infobar);
	}
}

