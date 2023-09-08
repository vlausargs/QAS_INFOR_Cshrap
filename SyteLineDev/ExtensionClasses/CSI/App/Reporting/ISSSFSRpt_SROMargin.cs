//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROMargin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROMargin
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROMarginSP(string SRONumBeg = null,
		string SRONumEnd = null,
		string CustNumBeg = null,
		string CustNumEnd = null,
		string SerNumBeg = null,
		string SerNumEnd = null,
		string IncNumBeg = null,
		string IncNumEnd = null,
		DateTime? TransDateBeg = null,
		DateTime? TransDateEnd = null,
		string RegionBeg = null,
		string RegionEnd = null,
		int? MatDetail = 0,
		int? LabDetail = 0,
		int? MiscDetail = 0,
		int? SROPageBreak = 0,
		int? TransDateOffSetBeg = null,
		string SortBy = "S",
		int? DisplayHeader = 0,
		DateTime? PostDateBeg = null,
		DateTime? PostDateEnd = null,
		int? PostDateOffSetBeg = null,
		int? ExBillCodeC = 0,
		int? ExBillCodeN = 0,
		int? ExBillCodeR = 0,
		int? ExBillCodeL = 0,
		int? ExBillCodeW = 0,
		int? ExBillCodeU = 0,
		DateTime? CloseDateBeg = null,
		DateTime? CloseDateEnd = null,
		string pSite = null);
	}
}

