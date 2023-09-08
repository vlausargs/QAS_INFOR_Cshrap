//PROJECT NAME: Data
//CLASS NAME: ILineAgeAptrxpAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILineAgeAptrxpAll
	{
		(int? ReturnCode,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar) LineAgeAptrxpAllSp(
			Guid? TRecid,
			DateTime? AgeByDate,
			string AgeBasis,
			int? DomCurr,
			int? UseHistRate,
			string PParmsCurrCode,
			string PVendorCurrCode,
			int? PPlaces,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar = null,
			decimal? AptrxpInvAmt = null,
			decimal? AptrxpAmtDisc = null,
			decimal? AptrxpDiscAmt = null,
			int? AptrxpFixedRate = null,
			DateTime? AptrxpDiscDate = null,
			decimal? AptrxpAmtPaid = null,
			decimal? AptrxpExchRate = null,
			string AptrxpType = null,
			DateTime? AptrxpDueDate = null,
			DateTime? AptrxpInvDate = null,
			string AptrxpVendNum = null,
			int? AptrxpVoucher = null,
			string AptrxpSite = null);
	}
}

