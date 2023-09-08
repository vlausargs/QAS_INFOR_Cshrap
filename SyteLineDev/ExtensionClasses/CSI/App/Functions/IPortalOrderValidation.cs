//PROJECT NAME: Data
//CLASS NAME: IPortalOrderValidation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalOrderValidation
	{
		(int? ReturnCode,
			int? pCreditLimitExceeded,
			int? pOrderCreditLimitExceeded,
			string pCorpCredCustNum,
			int? pOnCreditHold,
			string Infobar) PortalOrderValidationSp(
			string pCustNum,
			string pCoNum,
			int? pCreditLimitExceeded,
			int? pOrderCreditLimitExceeded,
			string pCorpCredCustNum,
			int? pOnCreditHold,
			string Infobar);
	}
}

