//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxableRevenue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TaxableRevenue : IRpt_TaxableRevenue
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TaxableRevenue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxableRevenueSP(string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? ShowDetail = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			TaxCodeType _TaxCodeStarting = TaxCodeStarting;
			TaxCodeType _TaxCodeEnding = TaxCodeEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			DateType _InvoiceDateStarting = InvoiceDateStarting;
			DateType _InvoiceDateEnding = InvoiceDateEnding;
			DateOffsetType _InvoiceDateStartingOffset = InvoiceDateStartingOffset;
			DateOffsetType _InvoiceDateEndingOffset = InvoiceDateEndingOffset;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TaxableRevenueSP";
				
				appDB.AddCommandParameter(cmd, "TaxCodeStarting", _TaxCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeEnding", _TaxCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStartingOffset", _InvoiceDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEndingOffset", _InvoiceDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
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
