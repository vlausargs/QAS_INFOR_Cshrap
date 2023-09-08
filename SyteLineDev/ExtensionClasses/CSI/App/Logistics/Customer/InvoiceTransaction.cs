//PROJECT NAME: Logistics
//CLASS NAME: InvoiceTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvoiceTransaction : IInvoiceTransaction
	{
		readonly IApplicationDB appDB;
		
		
		public InvoiceTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvoiceTransactionSp(string pSessionIDChar = null,
		int? pCallingProgram = null,
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
		int? pDisplayTotals = null,
		int? pSortByInvoice = null,
		int? pDisplayHeader = null,
		string pSite = null,
		string pToSite = null,
		string pStartBuilderInvNum = null,
		string pEndBuilderInvNum = null,
		int? pSeperateDRandCRtot = null,
		string Infobar = null)
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
			SiteType _pSite = pSite;
			SiteType _pToSite = pToSite;
			BuilderInvNumType _pStartBuilderInvNum = pStartBuilderInvNum;
			BuilderInvNumType _pEndBuilderInvNum = pEndBuilderInvNum;
			ListYesNoType _pSeperateDRandCRtot = pSeperateDRandCRtot;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoiceTransactionSp";
				
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
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToSite", _pToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartBuilderInvNum", _pStartBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndBuilderInvNum", _pEndBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeperateDRandCRtot", _pSeperateDRandCRtot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
