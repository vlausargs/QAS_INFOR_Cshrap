//PROJECT NAME: Reporting
//CLASS NAME: THARpt_SalesTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class THARpt_SalesTax : ITHARpt_SalesTax
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public THARpt_SalesTax(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) THARpt_SalesTaxSp(int? TranslateToDomesticCurrency = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		int? UnPostedVAT = 0,
		int? PostedVAT = 1,
		string BranchId = null)
		{
			FlagNyType _TranslateToDomesticCurrency = TranslateToDomesticCurrency;
			InvNumType _InvoiceStarting = InvoiceStarting;
			InvNumType _InvoiceEnding = InvoiceEnding;
			DateType _InvoiceDateStarting = InvoiceDateStarting;
			DateType _InvoiceDateEnding = InvoiceDateEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateOffsetType _InvoiceDateStartingOffset = InvoiceDateStartingOffset;
			DateOffsetType _InvoiceDateEndingOffset = InvoiceDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			ListYesNoType _UnPostedVAT = UnPostedVAT;
			ListYesNoType _PostedVAT = PostedVAT;
			BranchIdType _BranchId = BranchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THARpt_SalesTaxSp";
				
				appDB.AddCommandParameter(cmd, "TranslateToDomesticCurrency", _TranslateToDomesticCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceStarting", _InvoiceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceEnding", _InvoiceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStartingOffset", _InvoiceDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEndingOffset", _InvoiceDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnPostedVAT", _UnPostedVAT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostedVAT", _PostedVAT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BranchId", _BranchId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
