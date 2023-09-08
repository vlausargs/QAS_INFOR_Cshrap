//PROJECT NAME: Data
//CLASS NAME: IApp_CopySiteSpecProc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_CopySiteSpecProc
	{
		(int? ReturnCode,
			string Infobar) App_CopySiteSpecProcSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? AnalyzeOnly = 1,
			string Infobar = null);
	}
}

