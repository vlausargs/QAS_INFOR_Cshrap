//PROJECT NAME: BusInterface
//CLASS NAME: ILoadProcessQuote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadProcessQuote
	{
		(int? ReturnCode, Guid? RowPointer,
		string Infobar) LoadProcessQuoteSp(string pCoNum,
		string pActionCode,
		string pStat,
		string pCustNum,
		string pShipToID,
		DateTime? pQuoteDate,
		string pContact,
		string pPhone,
		string pShipCode,
		string pTermsCode,
		string pSlsman,
		string pCustQuote,
		string pConfirmationRef,
		string pShipPartial,
		string pShipEarly,
		Guid? RowPointer,
		string Infobar);
	}
}

