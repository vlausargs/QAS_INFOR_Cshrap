//PROJECT NAME: Data
//CLASS NAME: RepCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepCo : IRepCo
	{
		readonly IApplicationDB appDB;
		
		public RepCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			int? pAPSPullUpFlag = null)
		{
			SiteType _pDestSite = pDestSite;
			CoNumType _pCoNum = pCoNum;
			CurrCodeType _pCurrCode = pCurrCode;
			SiteType _pOrigSite = pOrigSite;
			UserCharFldType _pCharfld1 = pCharfld1;
			UserCharFldType _pCharfld2 = pCharfld2;
			UserCharFldType _pCharfld3 = pCharfld3;
			DateType _pCloseDate = pCloseDate;
			ContactType _pContact = pContact;
			ListYesNoType _pCreditHold = pCreditHold;
			ReasonCodeType _pCreditHoldReason = pCreditHoldReason;
			UserCodeType _pCreditHoldUser = pCreditHoldUser;
			DateType _pCreditHoldDate = pCreditHoldDate;
			CustNumType _pCustNum = pCustNum;
			CustPoType _pCustPo = pCustPo;
			CustSeqType _pCustSeq = pCustSeq;
			UserDateFldType _pDatefld = pDatefld;
			UserDeciFldType _pDecifld1 = pDecifld1;
			UserDeciFldType _pdecifld2 = pdecifld2;
			UserDeciFldType _pDecifld3 = pDecifld3;
			OrderDiscType _pDisc = pDisc;
			ListYesNoType _pEdiOrder = pEdiOrder;
			DateType _pEffDate = pEffDate;
			EndUserTypeType _pEndUserType = pEndUserType;
			EstNumType _pEstNum = pEstNum;
			DateType _pExpDate = pExpDate;
			CurrCodeType _pCoCurrCode = pCoCurrCode;
			ExchRateType _pExchRate = pExchRate;
			ListYesNoType _pFixedRate = pFixedRate;
			UserLogiFldType _pLogifld = pLogifld;
			DateType _pOrderDate = pOrderDate;
			PriceCodeType _pPriceCode = pPriceCode;
			ShipCodeType _pShipCode = pShipCode;
			SlsmanType _pSlsman = pSlsman;
			CoStatusType _pStat = pStat;
			TakenByType _pTakenBy = pTakenBy;
			TermsCodeType _pTermsCode = pTermsCode;
			CoTypeType _pType = pType;
			DescriptionType _pReasonDescription = pReasonDescription;
			InfobarType _Infobar = Infobar;
			VeryLongListType _UETListPairs = UETListPairs;
			ListYesNoType _pAPSPullUpFlag = pAPSPullUpFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepCoSp";
				
				appDB.AddCommandParameter(cmd, "pDestSite", _pDestSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrigSite", _pOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCharfld1", _pCharfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCharfld2", _pCharfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCharfld3", _pCharfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCloseDate", _pCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pContact", _pContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHold", _pCreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHoldReason", _pCreditHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHoldUser", _pCreditHoldUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHoldDate", _pCreditHoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustPo", _pCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustSeq", _pCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDatefld", _pDatefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDecifld1", _pDecifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pdecifld2", _pdecifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDecifld3", _pDecifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisc", _pDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEdiOrder", _pEdiOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEffDate", _pEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndUserType", _pEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEstNum", _pEstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExpDate", _pExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoCurrCode", _pCoCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExchRate", _pExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFixedRate", _pFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLogifld", _pLogifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderDate", _pOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPriceCode", _pPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipCode", _pShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSlsman", _pSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTakenBy", _pTakenBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReasonDescription", _pReasonDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAPSPullUpFlag", _pAPSPullUpFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
