//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InvoiceTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceTransactionSp(string pSessionIDChar = null,
		byte? pCallingProgram = null,
		string pStartingCustNum = null,
		string pEndingCustNum = null,
		string pStartingInvNumber = null,
		string pEndingInvNumber = null,
		DateTime? pStartingInvDate = null,
		DateTime? pEndingInvDate = null,
		DateTime? pStartingDueDate = null,
		DateTime? pEndingDueDate = null,
		string pInvoice = null,
		string pDebitMemo = null,
		string pCreditMemo = null,
		byte? pDisplayTotals = null,
		byte? pSortByInvoice = null,
		byte? pDisplayHeader = null,
		string pStartBuilderInvNum = null,
		string pEndBuilderInvNum = null,
		string pToSite = null,
		string pSite = null,
		byte? pSeperateDRandCRtot = null);
	}
	
	public class Rpt_InvoiceTransaction : IRpt_InvoiceTransaction
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InvoiceTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceTransactionSp(string pSessionIDChar = null,
		byte? pCallingProgram = null,
		string pStartingCustNum = null,
		string pEndingCustNum = null,
		string pStartingInvNumber = null,
		string pEndingInvNumber = null,
		DateTime? pStartingInvDate = null,
		DateTime? pEndingInvDate = null,
		DateTime? pStartingDueDate = null,
		DateTime? pEndingDueDate = null,
		string pInvoice = null,
		string pDebitMemo = null,
		string pCreditMemo = null,
		byte? pDisplayTotals = null,
		byte? pSortByInvoice = null,
		byte? pDisplayHeader = null,
		string pStartBuilderInvNum = null,
		string pEndBuilderInvNum = null,
		string pToSite = null,
		string pSite = null,
		byte? pSeperateDRandCRtot = null)
		{
			StringType _pSessionIDChar = pSessionIDChar;
			ListYesNoType _pCallingProgram = pCallingProgram;
			CustNumType _pStartingCustNum = pStartingCustNum;
			CustNumType _pEndingCustNum = pEndingCustNum;
			InvNumType _pStartingInvNumber = pStartingInvNumber;
			InvNumType _pEndingInvNumber = pEndingInvNumber;
			DateTimeType _pStartingInvDate = pStartingInvDate;
			DateTimeType _pEndingInvDate = pEndingInvDate;
			DateTimeType _pStartingDueDate = pStartingDueDate;
			DateTimeType _pEndingDueDate = pEndingDueDate;
			StringType _pInvoice = pInvoice;
			StringType _pDebitMemo = pDebitMemo;
			StringType _pCreditMemo = pCreditMemo;
			ListYesNoType _pDisplayTotals = pDisplayTotals;
			ListYesNoType _pSortByInvoice = pSortByInvoice;
			ListYesNoType _pDisplayHeader = pDisplayHeader;
			BuilderInvNumType _pStartBuilderInvNum = pStartBuilderInvNum;
			BuilderInvNumType _pEndBuilderInvNum = pEndBuilderInvNum;
			SiteType _pToSite = pToSite;
			SiteType _pSite = pSite;
			ListYesNoType _pSeperateDRandCRtot = pSeperateDRandCRtot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InvoiceTransactionSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCallingProgram", _pCallingProgram, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingCustNum", _pStartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingCustNum", _pEndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingInvNumber", _pStartingInvNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingInvNumber", _pEndingInvNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingInvDate", _pStartingInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingInvDate", _pEndingInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingDueDate", _pStartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingDueDate", _pEndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvoice", _pInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDebitMemo", _pDebitMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditMemo", _pCreditMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisplayTotals", _pDisplayTotals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSortByInvoice", _pSortByInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisplayHeader", _pDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartBuilderInvNum", _pStartBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndBuilderInvNum", _pEndBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToSite", _pToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeperateDRandCRtot", _pSeperateDRandCRtot, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
