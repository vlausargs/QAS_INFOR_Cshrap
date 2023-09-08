//PROJECT NAME: Data
//CLASS NAME: IGetEow.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEow
	{
		(int? ReturnCode,
			int? PEndTick,
			DateTime? PEndDate) GetEowSp(
			string PCalendar,
			DateTime? PDue,
			int? PEndTick,
			DateTime? PEndDate);
	}
}

