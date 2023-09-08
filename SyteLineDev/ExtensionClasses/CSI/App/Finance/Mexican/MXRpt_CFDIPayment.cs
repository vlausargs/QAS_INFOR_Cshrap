//PROJECT NAME: Finance
//CLASS NAME: MXRpt_CFDIPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXRpt_CFDIPayment : IMXRpt_CFDIPayment
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MXRpt_CFDIPayment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MXRpt_CFDIPaymentSp(
			int? pPaymentNumStarting = null,
			int? pPaymentNumEnding = null,
			DateTime? pPaymentDateStarting = null,
			DateTime? pPaymentDateEnding = null,
			string pCustomerStarting = null,
			string pCustomerEnding = null,
			string pBankCodeStarting = null,
			string pBankCodeEnding = null,
			int? DisplayHeader = null,
			string pArpmtTypeStarting = null,
			string pArpmtTypeEnding = null)
		{
			ArCheckNumType _pPaymentNumStarting = pPaymentNumStarting;
			ArCheckNumType _pPaymentNumEnding = pPaymentNumEnding;
			DateType _pPaymentDateStarting = pPaymentDateStarting;
			DateType _pPaymentDateEnding = pPaymentDateEnding;
			CustNumType _pCustomerStarting = pCustomerStarting;
			CustNumType _pCustomerEnding = pCustomerEnding;
			BankCodeType _pBankCodeStarting = pBankCodeStarting;
			BankCodeType _pBankCodeEnding = pBankCodeEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ArpmtTypeType _pArpmtTypeStarting = pArpmtTypeStarting;
			ArpmtTypeType _pArpmtTypeEnding = pArpmtTypeEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXRpt_CFDIPaymentSp";
				
				appDB.AddCommandParameter(cmd, "pPaymentNumStarting", _pPaymentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPaymentNumEnding", _pPaymentNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPaymentDateStarting", _pPaymentDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPaymentDateEnding", _pPaymentDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustomerStarting", _pCustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustomerEnding", _pCustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCodeStarting", _pBankCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCodeEnding", _pBankCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pArpmtTypeStarting", _pArpmtTypeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pArpmtTypeEnding", _pArpmtTypeEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
