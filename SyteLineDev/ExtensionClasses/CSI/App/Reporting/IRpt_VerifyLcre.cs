//PROJECT NAME: Reporting
//CLASS NAME: IRPT_VerifyLcre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_VerifyLcre
	{
		(int? ReturnCode,
			int? pError,
			string pErrMsg) RPT_VerifyLcreSP(
			string pCoNum,
			decimal? pShipValue,
			int? pConverted,
			DateTime? pTransDate,
			string pCurrCode,
			int? pError,
			string pErrMsg);
	}
}

