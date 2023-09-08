//PROJECT NAME: Data
//CLASS NAME: ILineAge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILineAge
	{
		(int? ReturnCode,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar) LineAgeSp(
			Guid? TRecid,
			DateTime? AgeByDate,
			string AgeBasis,
			int? DomCurr,
			int? UseHistRate,
			string PParmsCurrCode,
			int? PPlaces,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar = null);
	}
}

