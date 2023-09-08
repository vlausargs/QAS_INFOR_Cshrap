//PROJECT NAME: Data
//CLASS NAME: IRecalcJobTreeDates.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRecalcJobTreeDates
	{
		(int? ReturnCode,
			string Infobar) RecalcJobTreeDatesSp(
			string pJob,
			int? pSuffix,
			decimal? PHrsPerDay,
			int? PoverwriteDates,
			string Infobar);
	}
}

