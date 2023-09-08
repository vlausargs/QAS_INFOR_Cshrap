//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SalesTax : IRpt_SalesTax
	{
        readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SalesTax(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalesTaxSp(int? TranslateToDomesticCurrency = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
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
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SalesTaxSp";
				
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
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
