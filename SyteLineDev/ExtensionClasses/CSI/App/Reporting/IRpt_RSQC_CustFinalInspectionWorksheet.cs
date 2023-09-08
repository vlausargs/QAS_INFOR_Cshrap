//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CustFinalInspectionWorksheet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CustFinalInspectionWorksheet
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustFinalInspectionWorksheetSp(
			string BegCust = null,
			string EndCust = null,
			string BegItem = null,
			string EndItem = null,
			int? NumEntries = null,
			int? PrintWorksheet = null,
			int? DisplayHeader = null,
			int? PrintInternal = null,
			int? PrintExternal = null);
	}
}

