//PROJECT NAME: Data
//CLASS NAME: ISetHorizonWorkDays.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetHorizonWorkDays
	{
		(int? ReturnCode,
			string Infobar) SetHorizonWorkDaysSp(
			Guid? PStartRowid,
			string Infobar);
	}
}

