//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectMarginAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectMarginAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectMarginAnalysisSp(string StartingProject = null,
		string EndingProject = null,
		int? DisplayHeader = 1,
		string pSite = null);
	}
}

