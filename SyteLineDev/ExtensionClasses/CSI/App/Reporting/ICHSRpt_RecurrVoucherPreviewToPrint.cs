//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_RecurrVoucherPreviewToPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_RecurrVoucherPreviewToPrint
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_RecurrVoucherPreviewToPrintSp(string UserName,
		string pSite = null);
	}
}

