//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROReadyToInvoiceSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROReadyToInvoiceSub
	{
		int? SSSFSSROReadyToInvoiceSubFn(
			int? InclBillHold,
			string OperationStatus = "I",
			string SRONum = null,
			string CustNum = null,
			int? StartSROLine = null,
			int? EndSROLine = null,
			int? StartSROOper = null,
			int? EndSROOper = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			string PInvCred = null,
			int? PInclCalculated = null,
			int? PInclProject = null);
	}
}

