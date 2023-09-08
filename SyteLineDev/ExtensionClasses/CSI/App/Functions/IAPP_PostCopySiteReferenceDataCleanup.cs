//PROJECT NAME: Data
//CLASS NAME: IAPP_PostCopySiteReferenceDataCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_PostCopySiteReferenceDataCleanup
	{
		(int? ReturnCode,
			string Infobar) APP_PostCopySiteReferenceDataCleanupSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? AnalyzeOnly,
			string Infobar);
	}
}

