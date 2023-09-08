//PROJECT NAME: Reporting
//CLASS NAME: IRpt_LaborAnalysisbyWorkCenter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_LaborAnalysisbyWorkCenter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_LaborAnalysisbyWorkCenterSp(string StartWc = null,
		string EWc = null,
		string StartProductCode = null,
		string EProductCode = null,
		string StartItem = null,
		string EItem = null,
		DateTime? STransDate = null,
		DateTime? ETransDate = null,
		int? STransDateOffSET = null,
		int? ETransDateOffSET = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

