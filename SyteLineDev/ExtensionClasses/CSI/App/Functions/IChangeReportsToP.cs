//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToP
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToPSp(
			int? PRecover,
			int? PWasBlank,
			DateTime? PEffectiveDate,
			DateTime? PCtaDate,
			int? PSummaryOrDetail,
			string PSiteName,
			string Infobar);
	}
}

