//PROJECT NAME: Data
//CLASS NAME: ICustomerOpenRecordsReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerOpenRecordsReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CustomerOpenRecordsReportSp(
			string CustNumStarting = null,
			string CustNumEnding = null,
			string StatStarting = null,
			string StatEnding = null);
	}
}

