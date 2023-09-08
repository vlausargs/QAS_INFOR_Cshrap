//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxReceivable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TaxReceivable : IRpt_TaxReceivable
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TaxReceivable(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxReceivableSp(string StartingTaxCode = null,
		string EndingTaxCode = null,
		DateTime? StartingInvoiceDate = null,
		DateTime? EndingInvoiceDate = null,
		int? StartingInvoiceDateOffset = null,
		int? EndingInvoiceDateOffset = null,
		string StartingCust = null,
		string EndingCust = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			TaxCodeType _StartingTaxCode = StartingTaxCode;
			TaxCodeType _EndingTaxCode = EndingTaxCode;
			DateType _StartingInvoiceDate = StartingInvoiceDate;
			DateType _EndingInvoiceDate = EndingInvoiceDate;
			DateOffsetType _StartingInvoiceDateOffset = StartingInvoiceDateOffset;
			DateOffsetType _EndingInvoiceDateOffset = EndingInvoiceDateOffset;
			CustNumType _StartingCust = StartingCust;
			CustNumType _EndingCust = EndingCust;
			FlagNyType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TaxReceivableSp";
				
				appDB.AddCommandParameter(cmd, "StartingTaxCode", _StartingTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTaxCode", _EndingTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvoiceDate", _StartingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvoiceDate", _EndingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvoiceDateOffset", _StartingInvoiceDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvoiceDateOffset", _EndingInvoiceDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCust", _StartingCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCust", _EndingCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
