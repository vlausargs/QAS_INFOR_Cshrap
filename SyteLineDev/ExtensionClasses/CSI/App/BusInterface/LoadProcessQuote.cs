//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessQuote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessQuote : ILoadProcessQuote
	{
		readonly IApplicationDB appDB;
		
		
		public LoadProcessQuote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer,
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
		string Infobar)
		{
			StringType _pCoNum = pCoNum;
			StringType _pActionCode = pActionCode;
			StringType _pStat = pStat;
			StringType _pCustNum = pCustNum;
			StringType _pShipToID = pShipToID;
			DateType _pQuoteDate = pQuoteDate;
			ContactType _pContact = pContact;
			PhoneType _pPhone = pPhone;
			StringType _pShipCode = pShipCode;
			StringType _pTermsCode = pTermsCode;
			SlsmanType _pSlsman = pSlsman;
			CustPoType _pCustQuote = pCustQuote;
			OrderConfirmationRefType _pConfirmationRef = pConfirmationRef;
			StringType _pShipPartial = pShipPartial;
			StringType _pShipEarly = pShipEarly;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessQuoteSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActionCode", _pActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToID", _pShipToID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQuoteDate", _pQuoteDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pContact", _pContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPhone", _pPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipCode", _pShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSlsman", _pSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustQuote", _pCustQuote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfirmationRef", _pConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipPartial", _pShipPartial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipEarly", _pShipEarly, ParameterDirection.Input);
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
