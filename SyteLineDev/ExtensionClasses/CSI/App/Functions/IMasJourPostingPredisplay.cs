//PROJECT NAME: Data
//CLASS NAME: IMasJourPostingPredisplay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMasJourPostingPredisplay
	{
		(int? ReturnCode,
			DateTime? RStartDate,
			DateTime? REndDate,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			int? FiscalYear,
			string ROutOfRange,
			string RToPost,
			string RToPrint,
			string RPosted,
			string REmpty,
			string Infobar) MasJourPostingPredisplaySP(
			DateTime? RStartDate,
			DateTime? REndDate,
			DateTime? FiscalYearStartDate = null,
			DateTime? FiscalYearEndDate = null,
			int? FiscalYear = null,
			string ROutOfRange = null,
			string RToPost = null,
			string RToPrint = null,
			string RPosted = null,
			string REmpty = null,
			string Infobar = null);
	}
}

