//PROJECT NAME: Data
//CLASS NAME: ICommCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICommCalc
	{
		(int? ReturnCode,
			decimal? TCommBaseTot,
			decimal? TCommCalc,
			decimal? TCommBase,
			string Infobar) CommCalcSp(
			string TMode,
			string TInvNum,
			string TCoNum,
			string TCurSlsman,
			string TCurrCode,
			int? TPlaces,
			decimal? TExchRate,
			decimal? TRevPercent,
			decimal? TCommPercent,
			int? TCoLine,
			Guid? TInvItemRecid,
			decimal? TCommBaseTot,
			decimal? TCommCalc,
			decimal? TCommBase,
			string Infobar,
			string ParmsSite = null,
			int? CreateFromPackSlip = 0);
	}
}

