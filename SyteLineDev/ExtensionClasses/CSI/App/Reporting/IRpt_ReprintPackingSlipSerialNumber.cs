//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintPackingSlipSerialNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintPackingSlipSerialNumber
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintPackingSlipSerialNumberSp(string PckitemCoNum = null,
		int? PckitemCoLine = null,
		int? PckitemCoRelease = null,
		int? PckHdrPackNum = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

