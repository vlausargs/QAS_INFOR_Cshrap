//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROWorkOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROWorkOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROWorkOrderSp(string StartSRONum = null,
		string EndSRONum = null,
		int? StartSROLine = null,
		int? EndSROLine = null,
		int? StartSROOper = null,
		int? EndSROOper = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string StartSerNum = null,
		string EndSerNum = null,
		string Type = "P",
		int? PrintDetail = 1,
		int? PrintReasonCodes = 0,
		int? PrintShipTo = 0,
		int? PrintWarrantyInfo = 0,
		int? PrintSRONotes = 0,
		int? PrintLineNotes = 0,
		int? PrintOperNotes = 0,
		int? PrintCustomerNotes = 0,
		int? PrintReasonNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		int? DisplayHeader = null,
		int? PrintOpen = 1,
		int? PrintClosed = 0,
		int? PrintEstimate = 0,
		string pSite = null);
	}
}

