//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBChartofAccountMapping.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBChartofAccountMapping
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBChartofAccountMappingSp(string AccountStarting = null,
		string AccountEnding = null,
		string ExOptacChartType = null,
		int? DisplayHeader = null,
		string SortByTrx = null,
		string Name = null,
		string pSite = null);
	}
}

