//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransPostUtil.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransPostUtil
	{
		(int? ReturnCode, string InfoBar) SSSFSSROTransPostUtilSp(int? Commit = 0,
		int? Background = 0,
		string Type = "A",
		string StartSRONum = null,
		string EndSRONum = null,
		int? StartSROLine = null,
		int? EndSROLine = null,
		int? StartSROOper = null,
		int? EndSROOper = null,
		string StartSROType = null,
		string EndSROType = null,
		DateTime? StartTransDate = null,
		DateTime? EndTransDate = null,
		int? StartTransDateOffset = null,
		int? EndTransDateOffset = null,
		string StartDept = null,
		string EndDept = null,
		string StartPartnerId = null,
		string EndPartnerId = null,
		string StartOperCode = null,
		string EndOperCode = null,
		string StartOperWhse = null,
		string EndOperWhse = null,
		string StartTransWhse = null,
		string EndTransWhse = null,
		string StartLoc = null,
		string EndLoc = null,
		int? InclMatl = 1,
		int? InclLabor = 1,
		int? InclMisc = 1,
		int? InclLineMatl = 1,
		string BillCodesList = "CNWRLU",
		string GenerateReport = "N",
		string ReportOrderBy = "S",
		string RequestingUser = null,
		string InfoBar = null,
		string StartDocumentNum = null,
		string EndDocumentNum = null);
	}
}

