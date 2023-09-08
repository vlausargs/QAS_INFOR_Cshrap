//PROJECT NAME: Reporting
//CLASS NAME: IRPT_OrderCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_OrderCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_OrderCostSP(string ExOptacCoStat07 = null,
		int? ExMiscPrintLine = null,
		int? ExOptszShowDetail = null,
		string Begconum = null,
		string Endconum = null,
		int? Begcoline = null,
		int? Endcoline = null,
		int? Begcorelease = null,
		int? Endcorelease = null,
		string Begcustnum = null,
		string Endcustnum = null,
		DateTime? Begorderdate = null,
		DateTime? Endorderdate = null,
		int? BegorderdateOffset = null,
		int? EndorderdateOffset = null,
		int? PrintPrice = 0,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

