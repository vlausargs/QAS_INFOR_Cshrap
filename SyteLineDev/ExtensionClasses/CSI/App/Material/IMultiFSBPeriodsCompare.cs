//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBPeriodsCompare.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBPeriodsCompare
	{
		(int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) MultiFSBPeriodsCompareSp(
			string PeriodName = null,
			string Site = null,
			string CutOffDateLabel = null,
			DateTime? CutOffDate = null,
			string CtaDateLabel = null,
			DateTime? CtaDate = null,
			string Function = null,
			string PromptMsg = null,
			string PromptButtons = null,
			string Infobar = null);
	}
}

