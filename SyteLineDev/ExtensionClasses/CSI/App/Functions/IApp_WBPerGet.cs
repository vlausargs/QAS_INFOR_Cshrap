//PROJECT NAME: Data
//CLASS NAME: IApp_WBPerGet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_WBPerGet
	{
		(int? ReturnCode,
			DateTime? PerStart,
			DateTime? PerEnd,
			int? WorkDays,
			int? TotDays,
			string Infobar) App_WBPerGetSp(
			DateTime? AsOfDate,
			DateTime? PerStart,
			DateTime? PerEnd,
			int? WorkDays,
			int? TotDays,
			string Infobar);
	}
}

