//PROJECT NAME: Data
//CLASS NAME: IGetTick.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTick
	{
		(int? ReturnCode,
			int? ETick,
			int? PLoadError) GetTickSp(
			string PCalendar,
			int? FTick,
			int? NTick,
			string PTickType,
			int? ETick,
			int? PLoadError);
	}
}

