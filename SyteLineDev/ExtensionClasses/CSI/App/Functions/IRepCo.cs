//PROJECT NAME: Data
//CLASS NAME: IRepCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepCo
	{
		(int? ReturnCode,
			string Infobar) RepCoSp(
			string pDestSite,
			string pCoNum,
			string pCurrCode,
			string pOrigSite = null,
			string pCharfld1 = null,
			string pCharfld2 = null,
			string pCharfld3 = null,
			DateTime? pCloseDate = null,
			string pContact = null,
			int? pCreditHold = null,
			string pCreditHoldReason = null,
			string pCreditHoldUser = null,
			DateTime? pCreditHoldDate = null,
			string pCustNum = null,
			string pCustPo = null,
			int? pCustSeq = null,
			DateTime? pDatefld = null,
			decimal? pDecifld1 = null,
			decimal? pdecifld2 = null,
			decimal? pDecifld3 = null,
			decimal? pDisc = null,
			int? pEdiOrder = null,
			DateTime? pEffDate = null,
			string pEndUserType = null,
			string pEstNum = null,
			DateTime? pExpDate = null,
			string pCoCurrCode = null,
			decimal? pExchRate = null,
			int? pFixedRate = null,
			int? pLogifld = null,
			DateTime? pOrderDate = null,
			string pPriceCode = null,
			string pShipCode = null,
			string pSlsman = null,
			string pStat = null,
			string pTakenBy = null,
			string pTermsCode = null,
			string pType = null,
			string pReasonDescription = null,
			string Infobar = null,
			string UETListPairs = null,
			int? pAPSPullUpFlag = null);
	}
}

