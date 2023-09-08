//PROJECT NAME: Data
//CLASS NAME: IECOMM_Release_Estimate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IECOMM_Release_Estimate
	{
		(int? ReturnCode,
			string NewCoNum,
			int? SuccessFlag,
			string Infobar) ECOMM_Release_EstimateSp(
			string OrderNumber,
			string NewCoNum,
			int? SuccessFlag,
			string Infobar);
	}
}

