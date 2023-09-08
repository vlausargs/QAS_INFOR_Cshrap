//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARInvoiceCreditDebitMemo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ARInvoiceCreditDebitMemo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARInvoiceCreditDebitMemoSp(byte? PrePrint = null,
		string DocType = null,
		byte? PrintDocTxt = null,
		byte? PrintStdOrderTxt = null,
		byte? PrintCustMstrTxt = null,
		DateTime? DocDate = null,
		byte? TransDomCurr = null,
		byte? PrintEuroTotal = null,
		string StartCustomer = null,
		string EndCustomer = null,
		string StartInvoice = null,
		string EndInvoice = null,
		int? StartChkRef = null,
		int? EndChkRef = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		DateTime? StartIssueDate = null,
		DateTime? EndIssueDate = null,
		short? StartInvDateOffset = null,
		short? EndInvDateOffset = null,
		short? StartIssueDateOffset = null,
		short? EndIssueDateOffset = null,
		short? DocDateOffset = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		string BGSessionId = null,
		byte? PrintDiscountAmt = (byte)0,
		string pVoidOrDraft = null,
		byte? PrintHeaderOnAllPages = null,
		string pSite = null);
	}
	
	public class Rpt_ARInvoiceCreditDebitMemo : IRpt_ARInvoiceCreditDebitMemo
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ARInvoiceCreditDebitMemo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARInvoiceCreditDebitMemoSp(byte? PrePrint = null,
		string DocType = null,
		byte? PrintDocTxt = null,
		byte? PrintStdOrderTxt = null,
		byte? PrintCustMstrTxt = null,
		DateTime? DocDate = null,
		byte? TransDomCurr = null,
		byte? PrintEuroTotal = null,
		string StartCustomer = null,
		string EndCustomer = null,
		string StartInvoice = null,
		string EndInvoice = null,
		int? StartChkRef = null,
		int? EndChkRef = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		DateTime? StartIssueDate = null,
		DateTime? EndIssueDate = null,
		short? StartInvDateOffset = null,
		short? EndInvDateOffset = null,
		short? StartIssueDateOffset = null,
		short? EndIssueDateOffset = null,
		short? DocDateOffset = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		string BGSessionId = null,
		byte? PrintDiscountAmt = (byte)0,
		string pVoidOrDraft = null,
		byte? PrintHeaderOnAllPages = null,
		string pSite = null)
		{
			ListYesNoType _PrePrint = PrePrint;
			InfobarType _DocType = DocType;
			ListYesNoType _PrintDocTxt = PrintDocTxt;
			ListYesNoType _PrintStdOrderTxt = PrintStdOrderTxt;
			ListYesNoType _PrintCustMstrTxt = PrintCustMstrTxt;
			DateType _DocDate = DocDate;
			ListYesNoType _TransDomCurr = TransDomCurr;
			ListYesNoType _PrintEuroTotal = PrintEuroTotal;
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			InvNumType _StartInvoice = StartInvoice;
			InvNumType _EndInvoice = EndInvoice;
			ArInvSeqType _StartChkRef = StartChkRef;
			ArInvSeqType _EndChkRef = EndChkRef;
			GenericDateType _StartInvDate = StartInvDate;
			GenericDateType _EndInvDate = EndInvDate;
			GenericDateType _StartIssueDate = StartIssueDate;
			GenericDateType _EndIssueDate = EndIssueDate;
			DateOffsetType _StartInvDateOffset = StartInvDateOffset;
			DateOffsetType _EndInvDateOffset = EndInvDateOffset;
			DateOffsetType _StartIssueDateOffset = StartIssueDateOffset;
			DateOffsetType _EndIssueDateOffset = EndIssueDateOffset;
			DateOffsetType _DocDateOffset = DocDateOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			StringType _BGSessionId = BGSessionId;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			StringType _pVoidOrDraft = pVoidOrDraft;
			ListYesNoType _PrintHeaderOnAllPages = PrintHeaderOnAllPages;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ARInvoiceCreditDebitMemoSp";
				
				appDB.AddCommandParameter(cmd, "PrePrint", _PrePrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocType", _DocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDocTxt", _PrintDocTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStdOrderTxt", _PrintStdOrderTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustMstrTxt", _PrintCustMstrTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocDate", _DocDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvoice", _StartInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvoice", _EndInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartChkRef", _StartChkRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndChkRef", _EndChkRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartIssueDate", _StartIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndIssueDate", _EndIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDateOffset", _StartInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDateOffset", _EndInvDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartIssueDateOffset", _StartIssueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndIssueDateOffset", _EndIssueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocDateOffset", _DocDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVoidOrDraft", _pVoidOrDraft, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintHeaderOnAllPages", _PrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
