//PROJECT NAME: Data
//CLASS NAME: ICopySitesFsSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopySitesFsSchedule
	{
		(int? ReturnCode,
			string Infobar) CopySitesFsScheduleSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? AnalyzeOnly = 1,
			string Infobar = null);
	}
}

