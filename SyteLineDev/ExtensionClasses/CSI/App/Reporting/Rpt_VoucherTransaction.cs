//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VoucherTransaction : IRpt_VoucherTransaction
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VoucherTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherTransactionSp(string VendorStarting = null,
		string VendorEnding = null,
		string NameStarting = null,
		string NameEnding = null,
		int? PrintVoucherTotal = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? DistDateStarting = null,
		DateTime? DistDateEnding = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? DistDateStartingOffset = null,
		int? DistDateEndingOffset = null,
		string SortBy = null,
		string AuthStatus = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			NameType _NameStarting = NameStarting;
			NameType _NameEnding = NameEnding;
			FlagNyType _PrintVoucherTotal = PrintVoucherTotal;
			VoucherType _VoucherStarting = VoucherStarting;
			VoucherType _VoucherEnding = VoucherEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			DateType _DistDateStarting = DistDateStarting;
			DateType _DistDateEnding = DistDateEnding;
			DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
			DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
			DateOffsetType _DistDateStartingOffset = DistDateStartingOffset;
			DateOffsetType _DistDateEndingOffset = DistDateEndingOffset;
			InfobarType _SortBy = SortBy;
			StringType _AuthStatus = AuthStatus;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VoucherTransactionSp";
				
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameStarting", _NameStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameEnding", _NameEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintVoucherTotal", _PrintVoucherTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherStarting", _VoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherEnding", _VoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateStarting", _DistDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateEnding", _DistDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateStartingOffset", _DistDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistDateEndingOffset", _DistDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthStatus", _AuthStatus, ParameterDirection.Input);
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
