//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectInvoice : IRpt_ReprintProjectInvoice
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ReprintProjectInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectInvoiceSp(string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string ProjectStarting = null,
		string ProjectEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? PrintEuroTotal = null,
		int? TransDomCurr = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? PrintMilestoneNotes = null,
		int? PrintCustomerNotes = null,
		int? PrintProjectNotes = null,
		int? PrintStandardNotes = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? PrintDiscountAmt = 0,
		int? TaskId = null,
		string pSite = null,
		int? CallFromReport = 0)
		{
			InvNumType _InvoiceStarting = InvoiceStarting;
			InvNumType _InvoiceEnding = InvoiceEnding;
			DateType _InvoiceDateStarting = InvoiceDateStarting;
			DateType _InvoiceDateEnding = InvoiceDateEnding;
			ProjNumType _ProjectStarting = ProjectStarting;
			ProjNumType _ProjectEnding = ProjectEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			ListYesNoType _PrintEuroTotal = PrintEuroTotal;
			ListYesNoType _TransDomCurr = TransDomCurr;
			DateOffsetType _InvoiceDateStartingOffset = InvoiceDateStartingOffset;
			DateOffsetType _InvoiceDateEndingOffset = InvoiceDateEndingOffset;
			ListYesNoType _PrintMilestoneNotes = PrintMilestoneNotes;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintProjectNotes = PrintProjectNotes;
			ListYesNoType _PrintStandardNotes = PrintStandardNotes;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			ListYesNoType _CallFromReport = CallFromReport;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintProjectInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "InvoiceStarting", _InvoiceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceEnding", _InvoiceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStarting", _ProjectStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectEnding", _ProjectEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStartingOffset", _InvoiceDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEndingOffset", _InvoiceDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintMilestoneNotes", _PrintMilestoneNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjectNotes", _PrintProjectNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardNotes", _PrintStandardNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFromReport", _CallFromReport, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
