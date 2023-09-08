//PROJECT NAME: Data
//CLASS NAME: IVendorOpenRecordsReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVendorOpenRecordsReport
	{
		(ICollectionLoadResponse Data, int? ReturnCode) VendorOpenRecordsReportSp(
			string VendNumStarting = null,
			string VendNumEnding = null,
			string StatStarting = null,
			string StatEnding = null);
	}
}

