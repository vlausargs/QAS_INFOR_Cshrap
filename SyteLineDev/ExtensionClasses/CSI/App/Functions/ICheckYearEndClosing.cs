//PROJECT NAME: Data
//CLASS NAME: ICheckYearEndClosing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckYearEndClosing
	{
		(int? ReturnCode,
			string Infobar) CheckYearEndClosingSp(
			DateTime? BegDate,
			DateTime? EndDate,
			int? Post,
			string Infobar);
	}
}

