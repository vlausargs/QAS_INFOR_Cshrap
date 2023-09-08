//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCalcLineToBill.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCalcLineToBill
	{
		(int? ReturnCode,
			string Infobar) SSSFSConInvSubCalcLineToBillSp(
			Guid? SessionId,
			string iContract,
			int? iContLine,
			DateTime? iBillingThruDate,
			string Infobar,
			string FSParmsContSurchargeAcct = null,
			string FSParmsContSurchargeAcctUnit1 = null,
			string FSParmsContSurchargeAcctUnit2 = null,
			string FSParmsContSurchargeAcctUnit3 = null,
			string FSParmsContSurchargeAcctUnit4 = null,
			int? ContractFound = null,
			DateTime? ContractRenewalMoDay = null,
			string CurrCode = null,
			int? CurrPlaces = null);
	}
}

