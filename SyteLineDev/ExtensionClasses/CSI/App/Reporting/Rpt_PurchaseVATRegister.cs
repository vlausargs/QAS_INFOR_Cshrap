//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseVATRegister.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseVATRegister : IRpt_PurchaseVATRegister
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PurchaseVATRegister(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseVATRegisterSp(string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		DateTime? TaxPeriodDateStarting = null,
		DateTime? TaxPeriodDateEnding = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		int? TaxPeriodDateStartingOffset = null,
		int? TaxPeriodDateEndingOffset = null,
		string Description = null,
		int? DisplayHeader = null,
		int? DisplaySummaryInvoice = null,
		string ECCodeStarting = null,
		string ECCodeEnding = null,
		string ReportType = null,
		string SortBy = null,
		string pSite = null)
		{
			TaxCodeType _TaxCodeStarting = TaxCodeStarting;
			TaxCodeType _TaxCodeEnding = TaxCodeEnding;
			DateType _TaxPeriodDateStarting = TaxPeriodDateStarting;
			DateType _TaxPeriodDateEnding = TaxPeriodDateEnding;
			VendInvNumType _InvoiceStarting = InvoiceStarting;
			VendInvNumType _InvoiceEnding = InvoiceEnding;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			DateOffsetType _TaxPeriodDateStartingOffset = TaxPeriodDateStartingOffset;
			DateOffsetType _TaxPeriodDateEndingOffset = TaxPeriodDateEndingOffset;
			DescriptionType _Description = Description;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _DisplaySummaryInvoice = DisplaySummaryInvoice;
			EcCodeType _ECCodeStarting = ECCodeStarting;
			EcCodeType _ECCodeEnding = ECCodeEnding;
			StringType _ReportType = ReportType;
			SortDirectionPlusType _SortBy = SortBy;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseVATRegisterSp";
				
				appDB.AddCommandParameter(cmd, "TaxCodeStarting", _TaxCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeEnding", _TaxCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateStarting", _TaxPeriodDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateEnding", _TaxPeriodDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceStarting", _InvoiceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceEnding", _InvoiceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateStartingOffset", _TaxPeriodDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateEndingOffset", _TaxPeriodDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplaySummaryInvoice", _DisplaySummaryInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCodeStarting", _ECCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCodeEnding", _ECCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportType", _ReportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
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
