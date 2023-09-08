//PROJECT NAME: Data
//CLASS NAME: ISub1099FormPrinting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISub1099FormPrinting
	{
		(int? ReturnCode,
			decimal? TvPayYtd,
			decimal? TvPayLstYr,
			int? AnyPrinted,
			decimal? TMinPayments) Sub1099FormPrintingSp(
			string PVendNum = null,
			decimal? TvPayYtd = null,
			decimal? TvPayLstYr = null,
			int? AnyPrinted = null,
			int? TUseLstYrPayRec = null,
			decimal? TMinPayments = null,
			string TSite = null);
	}
}

