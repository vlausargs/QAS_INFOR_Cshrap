//PROJECT NAME: Data
//CLASS NAME: IAvgRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAvgRate
	{
		(int? ReturnCode,
			decimal? PAvgRate,
			string Infobar) AvgRateSp(
			string pSite,
			string PCurrCode,
			string PDomCurrCode,
			int? PUseBuyRate,
			DateTime? PStartDate,
			DateTime? PEndDate,
			decimal? PAvgRate,
			string Infobar);
	}
}

