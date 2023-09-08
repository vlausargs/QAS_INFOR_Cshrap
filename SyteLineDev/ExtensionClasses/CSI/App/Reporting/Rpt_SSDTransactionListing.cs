//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SSDTransactionListing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SSDTransactionListing : IRpt_SSDTransactionListing
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SSDTransactionListing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SSDTransactionListingSp(DateTime? PeriodStarting = null,
		DateTime? PeriodEnding = null,
		string ExOptszTransIndicator = null,
		string ExOptszSsdRefType = null,
		int? ExOptszSortByTransaction = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		int? PeriodStartingOffset = null,
		int? PeriodEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			DateType _PeriodStarting = PeriodStarting;
			DateType _PeriodEnding = PeriodEnding;
			InfobarType _ExOptszTransIndicator = ExOptszTransIndicator;
			InfobarType _ExOptszSsdRefType = ExOptszSsdRefType;
			ListYesNoType _ExOptszSortByTransaction = ExOptszSortByTransaction;
			VendNumType _CustomerStarting = CustomerStarting;
			VendNumType _CustomerEnding = CustomerEnding;
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			VendNumType _WhseStarting = WhseStarting;
			VendNumType _WhseEnding = WhseEnding;
			DateOffsetType _PeriodStartingOffset = PeriodStartingOffset;
			DateOffsetType _PeriodEndingOffset = PeriodEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SSDTransactionListingSp";
				
				appDB.AddCommandParameter(cmd, "PeriodStarting", _PeriodStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEnding", _PeriodEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszTransIndicator", _ExOptszTransIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSsdRefType", _ExOptszSsdRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSortByTransaction", _ExOptszSortByTransaction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodStartingOffset", _PeriodStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEndingOffset", _PeriodEndingOffset, ParameterDirection.Input);
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
