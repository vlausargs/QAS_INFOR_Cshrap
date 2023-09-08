//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APVoucherPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_APVoucherPosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_APVoucherPostingSp(string StartingVendNum = null,
		string EndingVendNum = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? DisDateStarting = null,
		DateTime? DisDateEnding = null,
		string AuthorizationStatus = null,
		string SortBy = null,
		byte? DisplayTotals = null,
		byte? DisplayHeader = null,
		byte? SeparateDrCrAmounts = null,
		string SessionIDChar = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_APVoucherPosting : IRpt_APVoucherPosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_APVoucherPosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_APVoucherPostingSp(string StartingVendNum = null,
		string EndingVendNum = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? DisDateStarting = null,
		DateTime? DisDateEnding = null,
		string AuthorizationStatus = null,
		string SortBy = null,
		byte? DisplayTotals = null,
		byte? DisplayHeader = null,
		byte? SeparateDrCrAmounts = null,
		string SessionIDChar = null,
		string BGSessionId = null,
		string pSite = null)
		{
			VendNumType _StartingVendNum = StartingVendNum;
			VendNumType _EndingVendNum = EndingVendNum;
			VoucherType _VoucherStarting = VoucherStarting;
			VoucherType _VoucherEnding = VoucherEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			DateType _DisDateStarting = DisDateStarting;
			DateType _DisDateEnding = DisDateEnding;
			StringType _AuthorizationStatus = AuthorizationStatus;
			StringType _SortBy = SortBy;
			ByteType _DisplayTotals = DisplayTotals;
			ByteType _DisplayHeader = DisplayHeader;
			ByteType _SeparateDrCrAmounts = SeparateDrCrAmounts;
			StringType _SessionIDChar = SessionIDChar;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_APVoucherPostingSp";
				
				appDB.AddCommandParameter(cmd, "StartingVendNum", _StartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendNum", _EndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherStarting", _VoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherEnding", _VoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisDateStarting", _DisDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisDateEnding", _DisDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthorizationStatus", _AuthorizationStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayTotals", _DisplayTotals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeparateDrCrAmounts", _SeparateDrCrAmounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
