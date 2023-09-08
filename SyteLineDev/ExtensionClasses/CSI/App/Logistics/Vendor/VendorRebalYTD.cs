//PROJECT NAME: Logistics
//CLASS NAME: VendorRebalYTD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorRebalYTD : IVendorRebalYTD
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public VendorRebalYTD(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) VendorRebalYTDSp(string StartingVendor,
		string EndingVendor,
		DateTime? YearStart,
		DateTime? YearEnd,
		DateTime? LastYearStart,
		DateTime? LastYearEnd,
		int? ResetPurchYTD,
		int? ResetPurchLstYr,
		int? ResetPayYTD,
		int? ResetPayLstYr,
		int? ResetDiscYTD,
		int? ResetDiscLstYr,
		DateTime? FiscalYearStart,
		DateTime? FiscalYearEnd,
		DateTime? LastFiscalYearStart,
		DateTime? LastFiscalYearEnd,
		int? ResetPayFiscalYTD,
		int? ResetPayFiscalLstYr,
		int? Reset1099PayYTD,
		int? Reset1099PayLstYr,
		string ProcessVar,
		int? ExceptionsOnly)
		{
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			DateType _YearStart = YearStart;
			DateType _YearEnd = YearEnd;
			DateType _LastYearStart = LastYearStart;
			DateType _LastYearEnd = LastYearEnd;
			ListYesNoType _ResetPurchYTD = ResetPurchYTD;
			ListYesNoType _ResetPurchLstYr = ResetPurchLstYr;
			ListYesNoType _ResetPayYTD = ResetPayYTD;
			ListYesNoType _ResetPayLstYr = ResetPayLstYr;
			ListYesNoType _ResetDiscYTD = ResetDiscYTD;
			ListYesNoType _ResetDiscLstYr = ResetDiscLstYr;
			DateType _FiscalYearStart = FiscalYearStart;
			DateType _FiscalYearEnd = FiscalYearEnd;
			DateType _LastFiscalYearStart = LastFiscalYearStart;
			DateType _LastFiscalYearEnd = LastFiscalYearEnd;
			ListYesNoType _ResetPayFiscalYTD = ResetPayFiscalYTD;
			ListYesNoType _ResetPayFiscalLstYr = ResetPayFiscalLstYr;
			ListYesNoType _Reset1099PayYTD = Reset1099PayYTD;
			ListYesNoType _Reset1099PayLstYr = Reset1099PayLstYr;
			StringType _ProcessVar = ProcessVar;
			ListYesNoType _ExceptionsOnly = ExceptionsOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorRebalYTDSp";
				
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YearStart", _YearStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YearEnd", _YearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastYearStart", _LastYearStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastYearEnd", _LastYearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPurchYTD", _ResetPurchYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPurchLstYr", _ResetPurchLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPayYTD", _ResetPayYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPayLstYr", _ResetPayLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetDiscYTD", _ResetDiscYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetDiscLstYr", _ResetDiscLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearStart", _FiscalYearStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearEnd", _FiscalYearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastFiscalYearStart", _LastFiscalYearStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastFiscalYearEnd", _LastFiscalYearEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPayFiscalYTD", _ResetPayFiscalYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPayFiscalLstYr", _ResetPayFiscalLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reset1099PayYTD", _Reset1099PayYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reset1099PayLstYr", _Reset1099PayLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessVar", _ProcessVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptionsOnly", _ExceptionsOnly, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
