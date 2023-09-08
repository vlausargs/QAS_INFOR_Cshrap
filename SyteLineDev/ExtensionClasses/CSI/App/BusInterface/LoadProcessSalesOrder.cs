//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessSalesOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessSalesOrder : ILoadProcessSalesOrder
	{
		readonly IApplicationDB appDB;
		
		
		public LoadProcessSalesOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer,
		string Infobar) LoadProcessSalesOrderSp(string pCoNum,
		string pActionCode,
		string pOrderType,
		string pStat,
		string pCustNum,
		DateTime? pOrderDate,
		string pContact,
		string pPhone,
		string pWhse,
		string pShipCode,
		string pTermsCode,
		string pSlsman,
		string pCustPo,
		string pConfirmationRef,
		string pShipPartial,
		string pShipEarly,
		string pUseSyteLinePrice,
		string pEstNum,
		string pMerchantID,
		decimal? pTotalAmt,
		string pGatewayStoredToken,
		string pLast4,
		string pCardType,
		decimal? pGatewayTransNum,
		Guid? RowPointer,
		string Infobar)
		{
			CoNumType _pCoNum = pCoNum;
			StringType _pActionCode = pActionCode;
			CoTypeType _pOrderType = pOrderType;
			StringType _pStat = pStat;
			StringType _pCustNum = pCustNum;
			DateType _pOrderDate = pOrderDate;
			ContactType _pContact = pContact;
			PhoneType _pPhone = pPhone;
			StringType _pWhse = pWhse;
			StringType _pShipCode = pShipCode;
			StringType _pTermsCode = pTermsCode;
			SlsmanType _pSlsman = pSlsman;
			CustPoType _pCustPo = pCustPo;
			OrderConfirmationRefType _pConfirmationRef = pConfirmationRef;
			StringType _pShipPartial = pShipPartial;
			StringType _pShipEarly = pShipEarly;
			StringType _pUseSyteLinePrice = pUseSyteLinePrice;
			CoNumType _pEstNum = pEstNum;
			CCIGatewayVendIdType _pMerchantID = pMerchantID;
			AmountType _pTotalAmt = pTotalAmt;
			LongDescType _pGatewayStoredToken = pGatewayStoredToken;
			CCICardLast4DigitsType _pLast4 = pLast4;
			CCICardTypeType _pCardType = pCardType;
			CCIGatewayTransNumType _pGatewayTransNum = pGatewayTransNum;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessSalesOrderSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActionCode", _pActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderType", _pOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderDate", _pOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pContact", _pContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPhone", _pPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWhse", _pWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipCode", _pShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSlsman", _pSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustPo", _pCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfirmationRef", _pConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipPartial", _pShipPartial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipEarly", _pShipEarly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseSyteLinePrice", _pUseSyteLinePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEstNum", _pEstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMerchantID", _pMerchantID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTotalAmt", _pTotalAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pGatewayStoredToken", _pGatewayStoredToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLast4", _pLast4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCardType", _pCardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pGatewayTransNum", _pGatewayTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}
