//PROJECT NAME: Production
//CLASS NAME: IShiftException.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IShiftException
	{
		(int? ReturnCode, int? CounterItem,
		string Infobar) ShiftExceptionSp(string FromResourceGroup,
		string ToResourceGroup,
		string ExceptionDescr,
		DateTime? StartDate,
		DateTime? EndDate,
		string Work,
		string Shift,
		int? AltNo,
		int? CounterItem,
		string Infobar);
	}
}

