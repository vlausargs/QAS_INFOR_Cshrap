//PROJECT NAME: Data
//CLASS NAME: IApp_WBFinYearPerStart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_WBFinYearPerStart
	{
		(int? ReturnCode,
			DateTime? PerStart,
			DateTime? YearStart,
			string Infobar,
			DateTime? PerEnd,
			DateTime? YearEnd) App_WBFinYearPerStartSp(
			DateTime? Date,
			DateTime? PerStart,
			DateTime? YearStart,
			string Infobar,
			DateTime? PerEnd = null,
			DateTime? YearEnd = null);
	}
}

