//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SlsmanReports.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SlsmanReports
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_SlsmanReportsSp(
			string UserName,
			int? DisplayLevel = 0);
	}
}

