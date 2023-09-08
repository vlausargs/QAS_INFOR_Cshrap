//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ApprovedNotInvoiced.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ApprovedNotInvoiced : IRpt_ApprovedNotInvoiced
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ApprovedNotInvoiced(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ApprovedNotInvoicedSp(string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? DateApprovedStarting = null,
		DateTime? DateApprovedEnding = null,
		int? DateApprovedStartingOffset = null,
		int? DateApprovedEndingOffset = null,
		int? DisplayReportHeader = 1,
		string pSite = null)
		{
			HighLowCharType _OrderStarting = OrderStarting;
			HighLowCharType _OrderEnding = OrderEnding;
			HighLowCharType _CustomerStarting = CustomerStarting;
			HighLowCharType _CustomerEnding = CustomerEnding;
			HighLowCharType _ItemStarting = ItemStarting;
			HighLowCharType _ItemEnding = ItemEnding;
			CurrentDateType _DateApprovedStarting = DateApprovedStarting;
			CurrentDateType _DateApprovedEnding = DateApprovedEnding;
			DateOffsetType _DateApprovedStartingOffset = DateApprovedStartingOffset;
			DateOffsetType _DateApprovedEndingOffset = DateApprovedEndingOffset;
			ListYesNoType _DisplayReportHeader = DisplayReportHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ApprovedNotInvoicedSp";
				
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateApprovedStarting", _DateApprovedStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateApprovedEnding", _DateApprovedEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateApprovedStartingOffset", _DateApprovedStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateApprovedEndingOffset", _DateApprovedEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayReportHeader", _DisplayReportHeader, ParameterDirection.Input);
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
