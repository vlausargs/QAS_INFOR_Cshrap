//PROJECT NAME: Production
//CLASS NAME: IPP_CopyQuoteTemplateToEstJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_CopyQuoteTemplateToEstJob
	{
		(int? ReturnCode,
			string Infobar) PP_CopyQuoteTemplateToEstJobSp(
			string SourceQuoteTemplate,
			string TargetJob,
			int? TargetSuffix,
			string Infobar);
	}
}

