//PROJECT NAME: Data
//CLASS NAME: ILineAgeSpMulti.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILineAgeSpMulti
	{
		(int? ReturnCode,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar) LineAgeSpMultiSp(
			Guid? TRecid,
			DateTime? AgeByDate,
			string AgeBasis,
			int? DomCurr,
			int? UseHistRate,
			string PParmsCurrCode,
			string PVendorCurrCode,
			string Site,
			int? PPlaces,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar = null,
			DateTime? CutOffDate = null);
	}
}

