//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SlsmanDirectReports.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SlsmanDirectReports
	{
		(int? ReturnCode, string SlsManList) CLM_SlsmanDirectReportsSp(string SlsmanID,
		int? IncludeDirectReports,
		string SlsManList);
	}
}

